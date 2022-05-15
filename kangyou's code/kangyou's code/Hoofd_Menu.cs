﻿using Newtonsoft.Json;

namespace Program.cs
{
    class Program
    {
        [Serializable]


        public class Voorgerechten
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public class Hoofdgerechten
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public class Vegatarischegerechten
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public class Dessert
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public class Alle_gerechten
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Nummer { get; set; }
        }
        public class Gerechten_kiezen
        {
            public int[] Nummer { get; set; }
            public string[] Name { get; set; }
            public double[] Price { get; set; }

        }
        public class Totaal_Bedrag
        {
            public string[] Gekozen_Gerechten { get; set; }
            public double[] Gekozen_Prijzen { get; set; }
        }
    }
}

