using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    partial class Program
    {
        public static void Main(string[] args)
        {
        Begin: Console.WriteLine("Menukaart \n");
            Console.WriteLine(" Kies 1 voor de Voorgerechten");
            Console.WriteLine(" Kies 2 voor de Hoofdgerechten");
            Console.WriteLine(" Kies 3 voor de Vegatarische gerechten");
            Console.WriteLine(" Kies 4 voor de Dessert \n ");
        dot: Console.WriteLine("\n");
            Console.WriteLine(" Type een nummer in : ");

            Voorgerechten menu = new Voorgerechten();
            {
                menu.Name = ("0. Tomatensoep");
                menu.Name1 = ("1. Kruidenbouillon");
                menu.Name2 = ("2. Vissoep");
                menu.Name3 = ("3. Wisselsoep(soep van de dag");
                menu.Name4 = ("4. Carpaccio van coquille met pstinaak");
                menu.Price = 5;
                menu.Price1 = 12;
                menu.Price2 = 4;
                menu.Price3 = 10;
                menu.Price4 = 12;
                menu.voorgerechten = new List<string>
                {
                };


            }
            string strResultJson = JsonConvert.SerializeObject(menu);
            File.WriteAllText(@"Hoofd_menu.json", strResultJson);

            strResultJson = String.Empty;
            strResultJson = File.ReadAllText(@"Hoofd_menu.json");
            Voorgerechten resultmenu = JsonConvert.DeserializeObject<Voorgerechten>(strResultJson);
            

            string a = Console.ReadLine();

            if (!int.TryParse(a, out int value))
            {
                Console.WriteLine("\n Probeer het opnieuw , vul een nummer in");
                goto dot;
            }
            else
            {
                int Choose_nummer = Convert.ToInt32(a);
                if (Choose_nummer == 1)
                {
                Een: Console.WriteLine("\n");
                    Console.Clear();

                    Console.WriteLine(resultmenu.ToString());


                    Console.WriteLine("\n\n\n\nType @ om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "@")
                    {
                        Console.Clear();
                        goto Begin;
                    }
                    else
                    {
                        goto Een;
                    }

                }
                else if (Choose_nummer == 2)
                {
                Twee: Console.WriteLine("\n");
                    Console.Clear();
                    Console.WriteLine("5. Bavette 200gr Amerikaans Black Angus       Prijs :5.5 ");
                    Console.WriteLine("6. 250gr Australisch Angus 2                  Prijs :10 ");
                    Console.WriteLine("7. Tournedos Rossini 200gr                    Prijs :20");
                    Console.WriteLine("8. Patatje Stoofvlees                         Prijs :21.5");
                    Console.WriteLine("9. Burger                                     Prijs :22.5");
                    Console.WriteLine("10.Burger b                                   Prijs :22.5");
                    Console.WriteLine("11.Cote De Boeuf                              Prijs :15.5");
                    Console.WriteLine("12.(V)   steak                                Prijs :17.5");
                    Console.WriteLine("13.Steak Tartare                              Prijs :19.5");
                    Console.WriteLine("14.Meat Carpaccio                             Prijs :2.5");

                    Console.WriteLine("\n\n\n Type @ om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "@")
                    {
                        Console.Clear();
                        goto Begin;
                    }
                    else
                    {
                        goto Twee;
                    }
                }
                else if (Choose_nummer == 3)
                {
                Drie: Console.WriteLine("\n");
                    Console.Clear();


                    Console.WriteLine("Type @ om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "@")
                    {
                        Console.Clear();
                        goto Begin;
                    }
                    else
                    {
                        goto Drie;
                    }
                }
                else if (Choose_nummer == 4)
                {
                Vier: Console.WriteLine("\n");
                    Console.Clear();

                    Console.WriteLine("Type @ om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "@")
                    {
                        Console.Clear();
                        goto Begin;
                    }
                    else
                    {
                        goto Vier;
                    }
                }
                else
                {
                    Console.WriteLine("\n  Nummer mislukt,  Kies tussen de nummers 1 , 2 -, 3 - 4");
                    goto dot;
                }

                
            }
            // int.Parse(Console.ReadLine());
        }
    }

}