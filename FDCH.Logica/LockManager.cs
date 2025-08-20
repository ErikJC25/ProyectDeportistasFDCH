//using System;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
//using System.Text;

//namespace FDCH.Logica
//{
//    /// <summary>
//    /// Clase encargada de gestionar el bloqueo de la aplicación mediante un archivo lock.json.
//    /// Permite que solo un usuario tenga acceso exclusivo a ciertas operaciones críticas.
//    /// </summary>
//    [DataContract]
//    internal class LockInfo
//    {
//        [DataMember]
//        public bool Bloqueado { get; set; }
//        [DataMember]
//        public string Usuario { get; set; }
//        [DataMember]
//        public string FechaHora { get; set; }
//    }

//    internal class LockManager
//    {
//        // Ruta del archivo de bloqueo en formato JSON
//        private readonly string lockFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lock.json");

//        /// <summary>
//        /// Intenta adquirir un bloqueo leyendo y escribiendo lock.json.
//        /// Si no está bloqueado, lo bloquea y devuelve true. Si ya está bloqueado por otro usuario, devuelve false.
//        /// </summary>
//        public bool AdquirirBloqueo(string usuario)
//        {
//            try
//            {
//                LockInfo info = LeerLockInfo();

//                if (info.Bloqueado)
//                    return false;

//                info.Bloqueado = true;
//                info.Usuario = usuario;
//                info.FechaHora = DateTime.Now.ToString("s");
//                EscribirLockInfo(info);
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Libera el bloqueo escribiendo en lock.json para indicar que está libre.
//        /// </summary>
//        public void LiberarBloqueo()
//        {
//            try
//            {
//                LockInfo info = LeerLockInfo();
//                info.Bloqueado = false;
//                info.Usuario = null;
//                info.FechaHora = null;
//                EscribirLockInfo(info);
//            }
//            catch
//            {
//                // Manejo de errores opcional
//            }
//        }

//        // Lee el estado del archivo lock.json, o crea uno nuevo si no existe
//        private LockInfo LeerLockInfo()
//        {
//            if (!File.Exists(lockFilePath))
//                return new LockInfo { Bloqueado = false, Usuario = null, FechaHora = null };

//            using (FileStream fs = new FileStream(lockFilePath, FileMode.Open))
//            {
//                var serializer = new DataContractJsonSerializer(typeof(LockInfo));
//                return (LockInfo)serializer.ReadObject(fs);
//            }
//        }

//        // Escribe el estado en el archivo lock.json
//        private void EscribirLockInfo(LockInfo info)
//        {
//            using (FileStream fs = new FileStream(lockFilePath, FileMode.Create))
//            {
//                var serializer = new DataContractJsonSerializer(typeof(LockInfo));
//                serializer.WriteObject(fs, info);
//            }
//        }
//    }
//}
