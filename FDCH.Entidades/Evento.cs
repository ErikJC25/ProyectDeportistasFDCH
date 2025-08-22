using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class Evento
    {
        public int id_evento { get; set; }
        public string nombre_evento { get; set; }
        public string lugar { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_fin { get; set; }
        public string tipo_evento { get; set; }
        public string nivel_evento { get; set; }
    }
}