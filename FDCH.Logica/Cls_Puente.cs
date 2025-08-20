using System;
using FDCH.Entidades;
using FDCH.Datos;

namespace FDCH.Logica
{
    public class Cls_Puente
    {
        private DbService _dbService = new DbService();
        //private LockManager _lockManager = new LockManager();
        private DriveService _driveService = new DriveService();

        public Cls_Puente()
        {
            // Si se necesita lógica adicional en el constructor
        }

        public Usuario AutenticarUsuario(string usuario, string contrasena)
        {
            // Aquí se llama al método de autenticación del servicio de datos
            Usuario usuarioAutenticado = _dbService.AutenticarUsuario(usuario, contrasena);
            if (usuarioAutenticado != null)
            {
                // Si el usuario es válido, puedes hacer algo con él
                // Por ejemplo, retornar el objeto Usuario
                return usuarioAutenticado;
            }
            else
            {
                // Si no es válido, puedes lanzar una excepción o retornar null
                return null;
            }
        }

        //public bool AdquirirBloqueo(string usuario)
        //{
        //    // Intenta adquirir el bloqueo para el usuario
        //    return _lockManager.AdquirirBloqueo(usuario);
        //}

        public void LiberarBloqueo()
        {
            // Libera el bloqueo actual
            //_lockManager.LiberarBloqueo();
        }

        public void SincronizarInicio()
        {
            // Descarga la base de datos y los archivos de log y lock del drive
            _driveService.DescargarArchivoDB();
            _driveService.DescargarLogYLock();
        }

        public void SubirCambios(string usuario)
        {
            // Sube la base de datos y los archivos de log y lock al drive
            _driveService.SubirArchivoDB(usuario);
            _driveService.SubirLogYLock(usuario);
        }
    }
}
