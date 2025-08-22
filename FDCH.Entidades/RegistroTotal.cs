using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCH.Entidades
{
    public class RegistroTotal
    {
        // Atributos de la tabla de Deportistas
        public int IdDeportista { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string TipoDiscapacidad { get; set; }

        // Atributos de la tabla de Tecnicos
        public int IdTecnico { get; set; }
        public string NombreCompletoTecnico { get; set; }

        // Atributos de la tabla de Eventos
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public string Lugar { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string TipoEvento { get; set; }
        public string NivelEvento { get; set; }


        public string MesInicioEvento { get; set; }
        public string AnioInicioEvento { get; set; }


        // Atributos de la tabla de Disciplinas
        public int IdDisciplina { get; set; }
        public string NombreDisciplina { get; set; }

        // Atributos de la tabla de Especialidades
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Modalidad { get; set; }

        // Atributos de la tabla de Competencias
        public int IdCompetencia { get; set; }
        public string Categoria { get; set; }
        public string Division { get; set; }
        public string NumeroParticipantes { get; set; }
        public string Record { get; set; }

        // Atributos de la tabla de Desempeno
        public int IdDesempeno { get; set; }
        public string Puntos { get; set; }
        public string Medalla { get; set; }
        public string Observaciones { get; set; }
        public string Tiempo { get; set; }
        public string Ubicacion { get; set; }

    }
}
