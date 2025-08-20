using System;
using System.IO;

namespace FDCH.Logica
{
    /// <summary>
    /// Servicio simulado para sincronización de archivos con un "Drive" (puede ser nube o carpeta compartida).
    /// Implementa métodos para descargar y subir la base de datos y archivos de log/bloqueo.
    /// </summary>
    internal class DriveService
    {
        // Ruta simulada del "Drive" (puedes cambiarla por una ruta de red o integración real)
        private readonly string driveFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DriveSimulado");
        private readonly string dbFileName = "deportistas.db";
        private readonly string logFileName = "app.log";
        private readonly string lockFileName = "app.lock";

        public DriveService()
        {
            // Asegura que la carpeta simulada exista
            if (!Directory.Exists(driveFolder))
                Directory.CreateDirectory(driveFolder);
        }

        /// <summary>
        /// Descarga el archivo de base de datos desde el "Drive" a la carpeta local.
        /// </summary>
        public void DescargarArchivoDB()
        {
            string origen = Path.Combine(driveFolder, dbFileName);
            string destino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../BaseDatos", dbFileName);
            destino = Path.GetFullPath(destino);

            if (File.Exists(origen))
                File.Copy(origen, destino, true);
        }

        /// <summary>
        /// Descarga los archivos de log y lock desde el "Drive" a la carpeta local.
        /// </summary>
        public void DescargarLogYLock()
        {
            string logOrigen = Path.Combine(driveFolder, logFileName);
            string logDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName);
            if (File.Exists(logOrigen))
                File.Copy(logOrigen, logDestino, true);

            string lockOrigen = Path.Combine(driveFolder, lockFileName);
            string lockDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, lockFileName);
            if (File.Exists(lockOrigen))
                File.Copy(lockOrigen, lockDestino, true);
        }

        /// <summary>
        /// Sube el archivo de base de datos desde la carpeta local al "Drive".
        /// </summary>
        /// <param name="usuario">Usuario que realiza la subida (puede usarse para logs).</param>
        public void SubirArchivoDB(string usuario)
        {
            string origen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../BaseDatos", dbFileName);
            origen = Path.GetFullPath(origen);
            string destino = Path.Combine(driveFolder, dbFileName);

            if (File.Exists(origen))
                File.Copy(origen, destino, true);
        }

        /// <summary>
        /// Sube los archivos de log y lock desde la carpeta local al "Drive".
        /// </summary>
        /// <param name="usuario">Usuario que realiza la subida (puede usarse para logs).</param>
        public void SubirLogYLock(string usuario)
        {
            string logOrigen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName);
            string logDestino = Path.Combine(driveFolder, logFileName);
            if (File.Exists(logOrigen))
                File.Copy(logOrigen, logDestino, true);

            string lockOrigen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, lockFileName);
            string lockDestino = Path.Combine(driveFolder, lockFileName);
            if (File.Exists(lockOrigen))
                File.Copy(lockOrigen, lockDestino, true);
        }
    }
}
