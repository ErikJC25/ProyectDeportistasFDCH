using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena_hash { get; set; }
        public string rol { get; set; }
    }
}