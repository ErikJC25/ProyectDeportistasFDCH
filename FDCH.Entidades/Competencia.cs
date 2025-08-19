using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class Competencia
    {
        public int id_competencia { get; set; }
        public string categoria { get; set; }
        public string division { get; set; }
        public int numero_participantes { get; set; }
        public string record { get; set; }
        public int id_evento { get; set; }
        public int id_especialidad { get; set; }
    }
}