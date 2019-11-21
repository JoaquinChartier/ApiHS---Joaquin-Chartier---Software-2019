using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHS
{
    public class MazoModelo
    {
        public string NombreMazo { get; set; }
        public HeroesEnum Clase { get; set; }
        public Dictionary<int,int> Cartas { get; set; }
        public string Codigo { get; set; }
        public FormatType TipoMazo { get; set; }

    }
        public class Mazo {
            public List<MazoModelo> Mazos { get; set; }
        }
}
