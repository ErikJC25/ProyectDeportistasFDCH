using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCH.Entidades
{
    /// <summary>
    /// DTO con los valores visibles de una fila del DataGridView en FrmGestionarDeportistas.
    /// Se pasa al formulario de fusión para rellenar la UI sin necesidad de nuevas consultas.
    /// </summary>
    public class SelectedRowDto
    {
        public int IdDeportista { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DisciplinasParticipadas { get; set; }
        public string Genero { get; set; }
        public string TipoDiscapacidad { get; set; }
    }
}
