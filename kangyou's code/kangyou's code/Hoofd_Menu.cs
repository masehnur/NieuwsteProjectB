
namespace Menu
{
    class Voorgerechten
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public string Name1 { get; set; }
        public int Price1 { get; set; }
        public string Name2 { get; set; }
        public int Price2 { get; set; }
        public string Name3 { get; set; }
        public int Price3 { get; set; }
        public string Name4 { get; set; }
        public int Price4 { get; set; }

        public List<string> voorgerechten { get; set; }

    public override string ToString()
        {
            return string.Format("Voorgerechten : \n\n" + Name + "                          " + Price + "\n" + Name1 + "                     " + Price1+ "\n" + Name2 + "                              " + Price2 + "\n" + Name3 + "          " + Price3 +"\n"+ Name4 + " " + Price4);
        }
    }
}

 

