using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        public static void Main(string[] args)
        {
        Begin: Console.WriteLine("Hallo! \n");
            Console.WriteLine(" Kies 1 voor de Voorgerechten");
            Console.WriteLine(" Kies 2 voor de Hoofdgerechten");
            Console.WriteLine(" Kies 3 voor de Vegatarische gerechten");
            Console.WriteLine(" Kies 4 voor de Dessert \n ");
        dot: Console.WriteLine("\n");

            Console.WriteLine(" Type een nummer in : ");



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
                    Console.WriteLine("Gerecht 1        Prijs :3.5 ");
                    Console.WriteLine("Gerecht 2");
                    Console.WriteLine("Gerecht 3");
                    Console.WriteLine("Gerecht 4");
                    Console.WriteLine("Gerecht 5");
                    Console.WriteLine("Gerecht 6");
                    Console.WriteLine("Gerecht 7");
                    Console.WriteLine("Gerecht 8");
                    Console.WriteLine("Gerecht 9");
                    Console.WriteLine("Gerecht 10");

                    Console.WriteLine("Type @ om terug te gaan");
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
                    Console.WriteLine("Gerecht 1        Prijs :5.5 ");
                    Console.WriteLine("Gerecht 2");
                    Console.WriteLine("Gerecht 3");
                    Console.WriteLine("Gerecht 4");
                    Console.WriteLine("Gerecht 5");
                    Console.WriteLine("Gerecht 6");
                    Console.WriteLine("Gerecht 7");
                    Console.WriteLine("Gerecht 8");
                    Console.WriteLine("Gerecht 9");
                    Console.WriteLine("Gerecht 10");

                    Console.WriteLine("Type @ om terug te gaan");
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
                    Console.WriteLine("Gerecht 1        Prijs :5.5 ");
                    Console.WriteLine("Gerecht 2");
                    Console.WriteLine("Gerecht 3");
                    Console.WriteLine("Gerecht 4");
                    Console.WriteLine("Gerecht 5");

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
                    Console.WriteLine("Gerecht 1        Prijs :5.5 ");
                    Console.WriteLine("Gerecht 2");
                    Console.WriteLine("Gerecht 3");
                    Console.WriteLine("Gerecht 4");
                    Console.WriteLine("Gerecht 5");
                    Console.WriteLine("Gerecht 6");

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