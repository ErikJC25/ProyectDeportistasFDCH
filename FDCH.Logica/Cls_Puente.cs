using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDCH.Entidades;
using FDCH.Datos;

namespace FDCH.Logica
{
    public class Cls_Puente
    {
        DbService objDB = new DbService();

        public Usuario AutenticarUsuario(string usuario, string contrasena)
        {
            // Aquí se llama al método de autenticación del servicio de datos
            Usuario usuarioAutenticado = objDB.AutenticarUsuario(usuario, contrasena);
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





    }
}
