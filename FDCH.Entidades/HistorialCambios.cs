using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class HistorialCambios
    {
        public int id_log { get; set; }
        public int id_usuario { get; set; }
        public string tabla_afectada { get; set; }
        public int id_registro_afectado { get; set; }
        public string accion { get; set; }
        public DateTime fecha_cambio { get; set; }
    }
}