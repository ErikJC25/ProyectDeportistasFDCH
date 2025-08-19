using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class Especialidad
    {
        public int id_especialidad { get; set; }
        public string nombre_especialidad { get; set; }
        public string modalidad { get; set; }
        public int id_disciplina { get; set; }
    }
}