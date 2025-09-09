using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCH.Entidades
{
    public class SelectedEspecialidadDto
    {
        public int IdEspecialidad { get; set; }
        public int IdDisciplina { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Modalidad { get; set; }
    }
}
