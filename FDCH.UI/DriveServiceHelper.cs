using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using FDCH.UI.Vistas;
using FDCH.Datos;
using System.Security.Cryptography;
namespace FDCH.UI
{
    public class DriveServiceHelper
    {
        private static string[] Scopes = { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private static string ApplicationName = "SQLiteDriveSync";
        private static DriveService _service;

        // 🔹 Inicializar el servicio (OAuth2)
        private static DriveService GetDriveService()
        {
            if (_service != null) return _service;

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string credentialsPath = Path.Combine(basePath, "credentials.json"); // JSON de credenciales
            string tokenPath = Path.Combine(basePath, "token.json");             // Token OAuth2

            if (!File.Exists(credentialsPath))
            {
                throw new FileNotFoundException("No se encontró el archivo credentials.json", credentialsPath);
            }

            UserCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(tokenPath, true)
                ).Result; // 👈 usamos .Result para esperar
            }

            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return _service;
        }
        // 🔹 Calcular hash MD5 de un archivo (para evitar duplicados)
        public static string CalcularMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        // 🔹 Subir archivo a Google Drive
        // 🔹 Subir archivo a Google Drive (con timestamp y control de duplicados)
        public static async Task<string> UploadFile(string filePath, string folderId = null)
        {
            var service = GetDriveService();

            // 📌 Generar nombre con timestamp
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            string finalName = $"{fileName}_{timestamp}{extension}";

            // 📌 Verificar duplicado (comparando MD5 con el último archivo en la carpeta)
            string localHash = CalcularMD5(filePath);
            var lastId = GetLastFileId(folderId);
            if (lastId != null)
            {
                var file = service.Files.Get(lastId);
                file.Fields = "id, md5Checksum";
                var lastFile = file.Execute();

                if (lastFile.Md5Checksum == localHash)
                {
                    Console.WriteLine("⚠ La base de datos no cambió, no se subirá un duplicado.");
                    return lastId; // se devuelve el ID existente
                }
            }

            // 📌 Metadata del archivo
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = finalName
            };

            if (folderId != null)
                fileMetadata.Parents = new[] { folderId };

            // 📌 Subida real
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";
                await request.UploadAsync();
            }

            var uploadedFile = request.ResponseBody;
            Console.WriteLine($"✅ Archivo subido: {uploadedFile.Id}");
            return uploadedFile.Id;
        }

        // 🔹 Descargar archivo desde Google Drive
        public static async Task DownloadFile(string fileId, string saveToPath)
        {
            var service = GetDriveService();
            var request = service.Files.Get(fileId);

            using (var stream = new MemoryStream())
            {
                await request.DownloadAsync(stream);
                using (var fileStream = new FileStream(saveToPath, FileMode.Create, FileAccess.Write))
                {
                    stream.Position = 0; // 👈 rebobinar memoria
                    stream.CopyTo(fileStream);
                }
            }
        }

        // 🔹 Obtener el ID del último archivo subido
        public static string GetLastFileId(string folderId = null)
        {
            var service = GetDriveService();
            string query = "trashed = false"; // solo archivos que no estén en la papelera

            if (!string.IsNullOrEmpty(folderId))
                query += $" and '{folderId}' in parents";

            var request = service.Files.List();
            request.Q = query;
            request.OrderBy = "createdTime desc"; // sigue funcionando
            request.PageSize = 1;
            request.Fields = "files(id, name, createdTime)"; // 👈 mantener createdTime

            var result = request.Execute();
            var file = result.Files.FirstOrDefault();
            /*cambio 
            if (file != null)
            {
                var fecha = file.CreatedTimeDateTimeOffset?.UtcDateTime; // 👈 usar propiedad nueva aquí
                Console.WriteLine($"Último archivo: {file.Name}, Fecha: {fecha}");
                return file.Id;
            } */

            return file?.Id;
        }
        // 🔹 Eliminar archivos viejos en una carpeta de Drive
        public static void DeleteOldBackups(string folderId, int daysToKeep = 7)
        {
            var service = GetDriveService();
            string query = $"'{folderId}' in parents and trashed = false";
            var request = service.Files.List();
            request.Q = query;
            request.Fields = "files(id, name, createdTime)";

            var result = request.Execute();
            var files = result.Files;

            DateTime limitDate = DateTime.UtcNow.AddDays(-daysToKeep);

            foreach (var file in files)
            {
                if (file.CreatedTimeDateTimeOffset?.UtcDateTime < limitDate)
                {
                    service.Files.Delete(file.Id).Execute();
                    Console.WriteLine($"🗑 Eliminado: {file.Name}");
                }
            }
        }
        /*
        public static async Task<bool> TryLock(string usuario, string folderId)
        {
            var service = GetDriveService();
            var lockFileId = GetFileIdByName("lock.json", folderId); // busca lock.json

            DateTime now = DateTime.UtcNow;

            if (lockFileId != null)
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "lock.json");
                await DownloadFile(lockFileId, tempPath);
                string json = File.ReadAllText(tempPath);
                dynamic lockData = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                string currentUser = lockData.usuario;
                DateTime lockTime = lockData.timestamp;

                // Si otro usuario tiene lock vigente
                if (currentUser != usuario && lockTime.AddMinutes(30) > now)
                {
                    return false;
                }
            }

            // Crear lock con tu usuario y timestamp
            var newLock = new
            {
                usuario = usuario,
                timestamp = now.ToString("o")
            };
            string lockTempPath = Path.Combine(Path.GetTempPath(), "lock.json");
            File.WriteAllText(lockTempPath, Newtonsoft.Json.JsonConvert.SerializeObject(newLock));

            await UploadFile(lockTempPath, folderId); // crea o sobrescribe lock.json
            File.Delete(lockTempPath);

            return true;
        }

        // 🔹 Buscar archivo por nombre en una carpeta
        public static string GetFileIdByName(string fileName, string folderId)
        {
            var service = GetDriveService();
            string query = $"name = '{fileName}' and '{folderId}' in parents and trashed = false";

            var request = service.Files.List();
            request.Q = query;
            request.Fields = "files(id, name)";
            request.PageSize = 1;

            var result = request.Execute();
            var file = result.Files.FirstOrDefault();
            return file?.Id;
        }

        // 🔹 Liberar lock al terminar
        public static async Task ReleaseLock(string usuario, string folderId)
        {
            var lockFileId = GetFileIdByName("lock.json", folderId);
            if (lockFileId != null)
            {
                var service = GetDriveService();
                await service.Files.Delete(lockFileId).ExecuteAsync();
            }
        }
        */




    }
}
