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
    }
}

