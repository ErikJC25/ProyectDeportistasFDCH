using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCH.Entidades
{
    public class HistorialViewModel
    {
        public int Id { get; set; }
        public string FechaHora { get; set; }
        public string Accion { get; set; }
        public string TablaAfectada { get; set; }
        public string NombreRegistro { get; set; }
        public string NombreUsuario { get; set; }


    }
}
