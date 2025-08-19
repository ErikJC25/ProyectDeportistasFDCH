using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class Desempeno
    {
        public int id_desempeno { get; set; }
        public int puntos { get; set; }
        public string medalla { get; set; }
        public string observaciones { get; set; }
        public string tiempo { get; set; }
        public string ubicacion { get; set; }
        public int id_deportista { get; set; }
        public int id_competencia { get; set; }
        public int id_tecnico { get; set; }
    }
}