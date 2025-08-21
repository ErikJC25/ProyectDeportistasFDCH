using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCH.Entidades
{
    public class HistorialCambio
    {
        public int id_log { get; set; }
        public int id_usuario { get; set; }
        public string tabla_afectada { get; set; }
        public int id_registro_afectado { get; set; }
        public string accion { get; set; }
        public DateTime fecha_cambio { get; set; }
    }
}
