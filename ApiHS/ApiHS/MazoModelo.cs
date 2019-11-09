using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHS
{
    public class MazoModelo
    {
        public string NombreMazo { get; set; }
        public string Clase { get; set; }
        public List<Card> Cartas { get; set; }
        public string Codigo { get; set; }
        public bool TipoMazo { get; set; }

    }
        public class Mazo {
            public List<MazoModelo> Mazos { get; set; }
        }
}
