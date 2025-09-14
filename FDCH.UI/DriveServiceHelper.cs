using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
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

            // Se define la ruta base, que es el directorio de la base de datos.
            string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Archivos");

            // credentials.json está dentro de la carpeta Archivos
            string credentialsPath = Path.Combine(dbDirectory, "credentials.json");

            // ⚡ Aquí indicamos la carpeta "token.json" (Google la usará como directorio)
            string tokenPath = Path.Combine(dbDirectory, "token.json");

            if (!File.Exists(credentialsPath))
                throw new FileNotFoundException(
                    "No se encontró el archivo credentials.json en la carpeta Archivos.",
                    credentialsPath
                );

            UserCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(tokenPath, true) // ✅ token.json = carpeta
                ).Result;
            }

            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return _service;
        }


        // 🔹 Calcular hash MD5 de un archivo
        public static string CalcularMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        // 🔹 Subir archivo con timestamp y evitar duplicados
        // 🔹 Subir archivo con timestamp y evitar duplicados
        public static async Task<string> UploadFile(string filePath, string folderId = null)
        {
            var service = GetDriveService();

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            string finalName = $"{fileName}_{timestamp}{extension}";

            // ⚡ Evitar duplicados comparando MD5
            string localHash = CalcularMD5(filePath);
            var lastId = GetLastFileId(folderId);
            if (lastId != null)
            {
                var file = service.Files.Get(lastId);
                file.Fields = "id, md5Checksum";
                var lastFile = file.Execute();

                if (lastFile.Md5Checksum == localHash)
                {
                    Console.WriteLine("⚠ La base no cambió, no se subirá duplicado.");
                    return lastId;
                }
            }

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = finalName
            };
            if (folderId != null)
                fileMetadata.Parents = new[] { folderId };

            Google.Apis.Drive.v3.FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";
                await request.UploadAsync();
            }

            var uploadedFile = request.ResponseBody;
            Console.WriteLine($"✅ Archivo subido: {uploadedFile.Id}");

            return uploadedFile.Id;
        }



        // 🔹 Eliminar archivos .db y .json antiguos de Drive de forma optimizada
        public static async Task DeleteOldFilesAsync(int daysToKeep = 30)
        {
            var service = GetDriveService();

            // Fecha límite: cualquier archivo más viejo se borrará
            DateTime limitDate = DateTime.UtcNow.AddDays(-daysToKeep);

            // Formato ISO 8601 para la query de Drive
            string limitDateStr = limitDate.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");

            // Query: solo archivos .db o .json que no estén en la papelera y creados antes de limitDate
            string query = $"trashed = false and (name contains '.db' or name contains '.json') and createdTime < '{limitDateStr}'";

            string pageToken = null;
            int totalDeleted = 0;

            do
            {
                var request = service.Files.List();
                request.Q = query;
                request.Fields = "nextPageToken, files(id, name, createdTime)";
                request.PageSize = 1000;
                request.PageToken = pageToken;

                var result = request.Execute();

                if (result.Files != null && result.Files.Count > 0)
                {
                    // Borrado en paralelo para acelerar
                    var deleteTasks = result.Files.Select(f =>
                    {
                        Console.WriteLine($"🗑 Eliminando: {f.Name}");
                        return service.Files.Delete(f.Id).ExecuteAsync();
                    });

                    await Task.WhenAll(deleteTasks);
                    totalDeleted += result.Files.Count;
                }

                pageToken = result.NextPageToken;
            } while (pageToken != null);

            Console.WriteLine($"✅ Eliminación completada. Total archivos eliminados: {totalDeleted}");
        }



        // 🔹 Descargar archivo desde Drive
        public static async Task DownloadFile(string fileId, string saveToPath)
        {
            var service = GetDriveService();
            var request = service.Files.Get(fileId);

            using (var stream = new MemoryStream())
            {
                await request.DownloadAsync(stream);
                stream.Position = 0;

                using (var fileStream = new FileStream(saveToPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }

        // 🔹 Obtener el último archivo .db subido
        public static string GetLastFileId(string folderId = null)
        {
            var service = GetDriveService();
            string query = "trashed = false";
            if (!string.IsNullOrEmpty(folderId))
                query += $" and '{folderId}' in parents";

            query += " and name contains '.db'"; // ⚠ Solo archivos .db

            var request = service.Files.List();
            request.Q = query;
            request.OrderBy = "createdTime desc";
            request.PageSize = 1;
            request.Fields = "files(id, name, createdTime)";

            var result = request.Execute();
            var file = result.Files.FirstOrDefault();

            if (file != null)
                Console.WriteLine($"Último archivo .db: {file.Name} ({file.Id})");

            return file?.Id;
        }



        // 🔹 Lock con toggle
        public enum LockResult
        {
            Granted,       // Se otorgó el bloqueo
            AlreadyLocked, // Otro usuario lo tiene activo
            Released       // Se liberó porque el mismo usuario lo tenía
        }

        public static async Task<LockResult> TryLock(string usuario, string folderId)
        {
            var lockFileId = GetFileIdByName("lock.json", folderId);
            DateTime now = DateTime.UtcNow;

            if (lockFileId != null)
            {
                string tempReadPath = Path.Combine(Path.GetTempPath(), "lock_read.json");
                await DownloadFile(lockFileId, tempReadPath);

                string json = File.ReadAllText(tempReadPath);
                dynamic lockData = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                string currentUser = lockData.usuario;
                DateTime lockTime = DateTime.Parse(lockData.timestamp.ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind);

                File.Delete(tempReadPath);

                // Otro usuario tiene el bloqueo y sigue vigente
                if (currentUser != usuario && lockTime.AddMinutes(30) > now)
                    return LockResult.AlreadyLocked;

                // Si el mismo usuario tenía el lock, lo liberamos
                if (currentUser == usuario)
                {
                    await ReleaseLock(usuario, folderId);
                    return LockResult.Released;
                }
            }

            // Crear un nuevo lock con archivo temporal único
            var newLock = new
            {
                usuario = usuario,
                timestamp = now.ToString("o")
            };

            string tempWritePath = Path.Combine(Path.GetTempPath(), $"lock_write_{Guid.NewGuid()}.json");
            File.WriteAllText(tempWritePath, Newtonsoft.Json.JsonConvert.SerializeObject(newLock));

            await UploadOrUpdateFile(tempWritePath, folderId, "lock.json");

            // Intentar borrar el archivo temporal de forma segura
            if (File.Exists(tempWritePath))
            {
                try
                {
                    File.Delete(tempWritePath);
                }
                catch (IOException)
                {
                    // Ignorar si el archivo aún está en uso por Windows
                }
            }

            return LockResult.Granted;
        }



        // 🔹 Buscar archivo por nombre
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

        // 🔹 Liberar lock
        public static async Task ReleaseLock(string usuario, string folderId)
        {
            var lockFileId = GetFileIdByName("lock.json", folderId);
            if (lockFileId == null) return;

            string tempPath = Path.Combine(Path.GetTempPath(), "lock_check.json");
            await DownloadFile(lockFileId, tempPath);

            dynamic lockData = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText(tempPath));
            File.Delete(tempPath);

            if (lockData.usuario == usuario)
            {
                var service = GetDriveService();
                await service.Files.Delete(lockFileId).ExecuteAsync();
            }
        }

        // 🔹 Chequear lock
        public static async Task<bool> CheckLock(string usuario, string folderId)
        {
            var lockFileId = GetFileIdByName("lock.json", folderId);
            if (lockFileId == null) return false;

            string tempReadPath = Path.Combine(Path.GetTempPath(), "lock_check.json");
            await DownloadFile(lockFileId, tempReadPath);

            string json = File.ReadAllText(tempReadPath);
            dynamic lockData = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string currentUser = lockData.usuario;
            DateTime lockTime = DateTime.Parse(lockData.timestamp.ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind);

            File.Delete(tempReadPath);

            return currentUser == usuario && lockTime.AddMinutes(30) > DateTime.UtcNow;
        }

        // 🔹 Subir o actualizar archivo
        public static async Task<string> UploadOrUpdateFile(string filePath, string folderId, string fileName)
        {
            var service = GetDriveService();
            var existingId = GetFileIdByName(fileName, folderId);

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = fileName
            };

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var ext = Path.GetExtension(fileName) ?? "";
                var mimeType = ext.Equals(".json", StringComparison.OrdinalIgnoreCase)
                    ? "application/json"
                    : "application/octet-stream";

                if (existingId != null)
                {
                    var updateRequest = service.Files.Update(fileMetadata, existingId, stream, mimeType);
                    updateRequest.Fields = "id";

                    var progress = await updateRequest.UploadAsync();
                    if (progress.Status == Google.Apis.Upload.UploadStatus.Completed && updateRequest.ResponseBody != null)
                        return updateRequest.ResponseBody.Id;

                    throw new Exception($"Error al actualizar archivo: {progress.Exception?.Message}");
                }
                else
                {
                    if (!string.IsNullOrEmpty(folderId))
                        fileMetadata.Parents = new[] { folderId };

                    var createRequest = service.Files.Create(fileMetadata, stream, mimeType);
                    createRequest.Fields = "id";
                    var progress = await createRequest.UploadAsync();

                    if (progress.Status == Google.Apis.Upload.UploadStatus.Completed && createRequest.ResponseBody != null)
                        return createRequest.ResponseBody.Id;

                    throw new Exception($"Error al crear archivo: {progress.Exception?.Message}");
                }
            }
        }


        public static async Task<string> SubirRegistroLock(string usuario, string folderLock)
        {
            var service = GetDriveService();

            var registro = new
            {
                usuario = usuario,
                fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            string tempPath = Path.Combine(Path.GetTempPath(), $"actualizado_{Guid.NewGuid()}.json");
            File.WriteAllText(tempPath, Newtonsoft.Json.JsonConvert.SerializeObject(registro, Newtonsoft.Json.Formatting.Indented));

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = $"actualizado_{usuario}_{DateTime.Now:yyyyMMdd_HHmmss}.json",
                Parents = new[] { folderLock }
            };

            Google.Apis.Drive.v3.FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                request = service.Files.Create(fileMetadata, stream, "application/json");
                request.Fields = "id";
                await request.UploadAsync();
            }

            File.Delete(tempPath);

            return fileMetadata.Name;
        }

    }
}
