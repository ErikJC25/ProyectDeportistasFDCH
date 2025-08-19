using System;
using System.Collections.Generic;

namespace FDCH.Entidades
{
    public class Deportista
    {
        public int id_deportista { get; set; }
        public string cedula { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string genero { get; set; }
        public string tipo_discapacidad { get; set; }
    }
}