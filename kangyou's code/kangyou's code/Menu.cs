using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program.cs.Program;






namespace Menu
{
    class Menukaart
    {

        public static string drawString(int Length, string character)
        {

            string side = "";
            for (int i = 0; i < Length; i++) { side += character; }
            return side;
        }
        public static void Main(string[] args)
        {
        Begin: Console.WriteLine("Menukaart \n");
            Console.WriteLine(" Kies 1 voor de Voorgerechten");
            Console.WriteLine(" Kies 2 voor de Hoofdgerechten");
            Console.WriteLine(" Kies 3 voor de Vegatarische gerechten");
            Console.WriteLine(" Kies 4 voor de Dessert \n ");
            Console.WriteLine(" Kies 5 voor een keuze maken \n ");
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
                    var voorgerechten = new List<Voorgerechten>
                    {
                        new Voorgerechten()
                        {
                            Name = "1. Tomatensoep",
                            Price = 12.0
                        },
                        new Voorgerechten()
                        {
                            Name = "2. Groentesoep",
                            Price = 6.0
                        },
                        new Voorgerechten()
                        {
                            Name = "3. Thaise ‘Tom kha kai’ soep",
                            Price = 6.0
                        },
                        new Voorgerechten()
                        {
                            Name = "4. Carpaccio truffo",
                            Price = 13.0
                        },
                        new Voorgerechten()
                        {
                            Name = "5. Asian surf en turf",
                            Price = 14.0
                        },
                        new Voorgerechten()
                        {
                            Name = "6. Nederlands Kwartet",
                            Price = 14.0
                        },
                        new Voorgerechten()
                        {
                            Name = "7. Tripel Gerookte Zalm",
                            Price = 12.0
                        },
                    };
                    var GerechtenJson = JsonConvert.SerializeObject(voorgerechten);
                    foreach (Voorgerechten g in voorgerechten)
                    {
                        string display_A = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_A);
                    }

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
                    var hoofdgerechten = new List<Hoofdgerechten>
                    {
                        new Hoofdgerechten()
                        {
                            Name = "8. Schotel kip shoarma",
                            Price = 12.0
                        },
                        new Hoofdgerechten()
                        {
                            Name = "9. Schotel Pistache Halab",
                            Price = 6.0
                        },
                        new Hoofdgerechten()
                        {
                            Name = "10. Schotel falafel",
                            Price = 6.0
                        },
                        new Hoofdgerechten()
                        {
                            Name = "11. Hotwings",
                            Price = 13.0
                        },
                        new Hoofdgerechten()
                        {
                            Name = "12. Kip shoarma los",
                            Price = 14.0
                        },
                        new Hoofdgerechten()
                        {
                            Name = "13. Schote mexicano",
                            Price = 14.0
                        },
                        new Hoofdgerechten()
                        {
                            Name = "14. Schotel Fajita",
                            Price = 12.0
                        },
                    };
                    var GerechtenJson = JsonConvert.SerializeObject(hoofdgerechten);
                    foreach (Hoofdgerechten g in hoofdgerechten)
                    {
                        string display_B= $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_B);
                    }
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
                    var vegatarischegerechten = new List<Vegatarischegerechten>
                    {
                        new Vegatarischegerechten()
                        {
                            Name = "15. Veg Lasagne",
                            Price = 12.0
                        },
                        new Vegatarischegerechten()
                        {
                            Name = "16. Pittige pompoenstoof",
                            Price = 6.0
                        },
                        new Vegatarischegerechten()
                        {
                            Name = "17. Veg Goulash",
                            Price = 6.0
                        },
                        new Vegatarischegerechten()
                        {
                            Name = "18. Veg Pasta",
                            Price = 13.0
                        },
                        new Vegatarischegerechten()
                        {
                            Name = "19. Kip shoarma los",
                            Price = 14.0
                        },
                        new Vegatarischegerechten()
                        {
                            Name = "20. Zoete aardappel curry",
                            Price = 14.0
                        },
                        new Vegatarischegerechten()
                        {
                            Name = "21. Veg Burger",
                            Price = 12.0
                        },
                    };
                    var GerechtenJson = JsonConvert.SerializeObject(vegatarischegerechten); 
                    foreach (Vegatarischegerechten g in vegatarischegerechten)
                    {
                        string display_C = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_C);
                    }

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
                    var dessert = new List<Dessert>
                    {
                        new Dessert()
                        {
                            Name = "22. Vanilla ijs",
                            Price = 3.0
                        },
                        new Dessert()
                        {
                            Name = "23. crembule",
                            Price = 6.0
                        },
                        new Dessert()
                        {
                            Name = "24. Oreotaart",
                            Price = 6.0
                        },
                        new Dessert()
                        {
                            Name = "25. Gebakken banaantjes",
                            Price = 7.0
                        },
                        new Dessert()
                        {
                            Name = "26. crepe",
                            Price = 2.0
                        },
                        new Dessert()
                        {
                            Name = "27. dessert van de dag",
                            Price = 14.0
                        },
                        new Dessert()
                        {
                            Name = "28. warme koffie",
                            Price = 12.0
                        },
                    };
                    var GerechtenJson = JsonConvert.SerializeObject(dessert);
                    
                    foreach (Dessert g in dessert)
                    {
                        string display_D = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_D);
                    }

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
                else if (Choose_nummer == 5)
                {
                vijf:

                    Console.Clear();
                
                    Console.WriteLine("Voeg een gerecht toe aan je bestelling\n");
                    c:
                    Console.WriteLine("Kies 1 om de Menukaart te zien");
                    Console.WriteLine("Kies 2 om een gerecht te kiezen");

                    string c = Console.ReadLine();

                    if (!int.TryParse(c, out int val))
                    {
                        
                        goto vijf;
                        Console.WriteLine("\n Probeer het opnieuw , vul een nummer in");
                    }
                    else
                    {
                        int Choose_nummer1 = Convert.ToInt32(c);

                        if (Choose_nummer1 == 1)
                        {
                            var alle_gerechten = new List<Alle_gerechten>
                            {
                                new Alle_gerechten()
                                {
                                    Name = "1. Tomatensoep",
                                    Price = 12.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "2. Groentesoep",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "3. Thaise ‘Tom kha kai’ soep",
                                    Price = 6.0
                                },
                                new Alle_gerechten
                                {
                                    Name = "4. Carpaccio truffo",
                                    Price = 13.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "5. Asian surf en turf",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "6. Nederlands Kwartet",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "7. Tripel Gerookte Zalm",
                                    Price = 12.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "8. Schotel kip shoarma",
                                    Price = 12.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "9. Schotel Pistache Halab",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "10. Schotel falafel",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "11. Hotwings",
                                    Price = 13.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "12. Kip shoarma los",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "13. Schote mexicano",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "14. Schotel Fajita",
                                    Price = 12.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "15. Veg Lasagne",
                                    Price = 12.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "16. Pittige pompoenstoof",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "17. Veg Goulash",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "18. Veg Pasta",
                                    Price = 13.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "19. Kip shoarma los",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "20. Zoete aardappel curry",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "21. Veg Burger",
                                    Price = 12.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "22. Vanilla ijs",
                                    Price = 3.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "23. crembule",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "24. Oreotaart",
                                    Price = 6.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "25. Gebakken banaantjes",
                                    Price = 7.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "26. crepe",
                                    Price = 2.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "27. dessert van de dag",
                                    Price = 14.0
                                },
                                new Alle_gerechten()
                                {
                                    Name = "28. warme koffie",
                                    Price = 12.0
                                },
                            };
                            var GerechtenJson = JsonConvert.SerializeObject(alle_gerechten);
                            foreach (Alle_gerechten g in alle_gerechten)
                            {
                                string display_A = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                                Console.WriteLine(display_A);
                                
                            }
                        }
                        else if (Choose_nummer1 == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Kies de nummer : ");
                            string Kiesnummer_1 = Console.ReadLine();
                            if (Kiesnummer_1 == "1")
                            {
                                Console.Clear();
                                Console.WriteLine("1. Tomatensoep    $12 \n\n");
                                Console.WriteLine("Totaalbedrag :              $12\n\n\n\n");

                                Console.WriteLine("Nog een  gerecht toevoegen ? kies nummer [1]\n\n ");
                                Console.WriteLine("Verder gaan met reserveren ? kies [2] ");
                                string meer_bestellen=  Console.ReadLine();
                                if (meer_bestellen == "1")
                                {
                                    Console.WriteLine("Kies de nummer : ");
                                    string Kiesnummer_2 = Console.ReadLine();
                                    if (Kiesnummer_2 == "2")
                                    {
                                        Console.WriteLine("1. Tomatensoep    $12");
                                        Console.WriteLine("2. Groentesoep    $6");

                                        Console.WriteLine("Totaalbedrag :              $18\n\n\n\n");
                                    }
                                }

                            }

                            
                        }
                    }





                        Console.WriteLine("Type @ om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "@")
                    {
                        Console.Clear();
                        goto c;
                    }
                    else
                    {
                        goto vijf;
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