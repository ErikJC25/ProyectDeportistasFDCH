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

        // 🔹 Subir archivo a Google Drive
        public static async Task<string> UploadFile(string filePath, string folderId = null)
        {
            var service = GetDriveService();

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath)
            };

            if (folderId != null)
                fileMetadata.Parents = new[] { folderId };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";
                await request.UploadAsync();
            }

            var file = request.ResponseBody;
            return file.Id;
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

            if (file != null)
            {
                var fecha = file.CreatedTimeDateTimeOffset?.UtcDateTime; // 👈 usar propiedad nueva aquí
                Console.WriteLine($"Último archivo: {file.Name}, Fecha: {fecha}");
                return file.Id;
            }

            return null;
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
                }
            }
        }

    }
}
