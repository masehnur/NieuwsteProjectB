namespace JsonParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hoofdmenu menu = new Hoofdmenu();
            {
                Naam = "Gerecht 1";
                Prijs = 5;
            }
            string strResultJson = JsonConvert.SerializeObject(menu);
            
        }
    }
}