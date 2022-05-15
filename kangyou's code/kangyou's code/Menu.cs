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
            Console.WriteLine(" Kies [1] voor de Voorgerechten");
            Console.WriteLine(" Kies [2] voor de Hoofdgerechten");
            Console.WriteLine(" Kies [3] voor de Vegatarische gerechten");
            Console.WriteLine(" Kies [4] voor de Dessert \n ");
            Console.WriteLine(" Kies [5] voor een keuze maken \n\n ");
        dot: Console.WriteLine("\n\n\n");
            Console.WriteLine("Type een nummer in : ");


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
                    File.WriteAllText(@"Voorgerechten.json", GerechtenJson);
                    foreach (Voorgerechten g in voorgerechten)
                    {
                        string display_A = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_A);
                    }

                    Console.WriteLine("\n\n\n\nType b om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "b")
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
                    File.WriteAllText(@"Hoofdgerechten.json", GerechtenJson);
                    foreach (Hoofdgerechten g in hoofdgerechten)
                    {
                        string display_B = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_B);
                    }
                    Console.WriteLine("\n\n\n Type b om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "b")
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
                    File.WriteAllText(@"Vegagerechten.json", GerechtenJson);
                    foreach (Vegatarischegerechten g in vegatarischegerechten)
                    {
                        string display_C = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_C);
                    }

                    Console.WriteLine("Type b om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "b")
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
                    File.WriteAllText(@"Dessert_gerechten.json", GerechtenJson);
                    foreach (Dessert g in dessert)
                    {
                        string display_D = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                        Console.WriteLine(display_D);
                    }

                    Console.WriteLine("Type b om terug te gaan");
                    string Back = Console.ReadLine();
                    if (Back == "b")
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
                    Console.WriteLine("Kies [1] om de Menukaart te zien");
                    Console.WriteLine("Kies [2] om een gerecht te kiezen");
                    Console.WriteLine("\n\n\n\nType b om terug te gaan");

                    string c = Console.ReadLine();
                    if (c == "b")
                    {
                        Console.Clear();
                        goto Begin;
                    }

                    if (!int.TryParse(c, out int val))
                    {

                        goto vijf;
                        Console.WriteLine("\n Probeer het opnieuw , vul een nummer in");
                    }
                    else
                    {

                        int Choose_nummer1 = Convert.ToInt32(c);

                        // Kies 1 om de Menukaart te zien
                        if (Choose_nummer1 == 1)
                        {
                            var alle_gerechten = new List<Alle_gerechten>
                            {
                                new Alle_gerechten()
                                {
                                    Name = "1. Tomatensoep",
                                    Price = 12.0,
                                    Nummer = 1
                                },
                                new Alle_gerechten()
                                {
                                    Name = "2. Groentesoep",
                                    Price = 6.0,
                                    Nummer = 2
                                },
                                new Alle_gerechten()
                                {
                                    Name = "3. Thaise ‘Tom kha kai’ soep",
                                    Price = 6.0,
                                    Nummer = 3
                                },
                                new Alle_gerechten
                                {
                                    Name = "4. Carpaccio truffo",
                                    Price = 13.0,
                                    Nummer = 4
                                },
                                new Alle_gerechten()
                                {
                                    Name = "5. Asian surf en turf",
                                    Price = 14.0,
                                    Nummer = 5
                                },
                                new Alle_gerechten()
                                {
                                    Name = "6. Nederlands Kwartet",
                                    Price = 14.0,
                                    Nummer = 6
                                },
                                new Alle_gerechten()
                                {
                                    Name = "7. Tripel Gerookte Zalm",
                                    Price = 12.0,
                                    Nummer = 7
                                },
                                new Alle_gerechten()
                                {
                                    Name = "8. Schotel kip shoarma",
                                    Price = 12.0,
                                    Nummer = 8
                                },
                                new Alle_gerechten()
                                {
                                    Name = "9. Schotel Pistache Halab",
                                    Price = 6.0,
                                    Nummer = 9
                                },
                                new Alle_gerechten()
                                {
                                    Name = "10. Schotel falafel",
                                    Price = 6.0,
                                    Nummer = 10
                                },
                                new Alle_gerechten()
                                {
                                    Name = "11. Hotwings",
                                    Price = 13.0,
                                    Nummer = 11
                                },
                                new Alle_gerechten()
                                {
                                    Name = "12. Kip shoarma los",
                                    Price = 14.0,
                                    Nummer = 12
                                },
                                new Alle_gerechten()
                                {
                                    Name = "13. Schote mexicano",
                                    Price = 14.0,
                                    Nummer = 13
                                },
                                new Alle_gerechten()
                                {
                                    Name = "14. Schotel Fajita",
                                    Price = 12.0,
                                    Nummer = 14
                                },
                                new Alle_gerechten()
                                {
                                    Name = "15. Veg Lasagne",
                                    Price = 12.0,
                                    Nummer = 15
                                },
                                new Alle_gerechten()
                                {
                                    Name = "16. Pittige pompoenstoof",
                                    Price = 6.0,
                                    Nummer = 16
                                },
                                new Alle_gerechten()
                                {
                                    Name = "17. Veg Goulash",
                                    Price = 6.0,
                                    Nummer = 17
                                },
                                new Alle_gerechten()
                                {
                                    Name = "18. Veg Pasta",
                                    Price = 13.0,
                                    Nummer = 18
                                },
                                new Alle_gerechten()
                                {
                                    Name = "19. Kip shoarma los",
                                    Price = 14.0,
                                    Nummer = 19
                                },
                                new Alle_gerechten()
                                {
                                    Name = "20. Zoete aardappel curry",
                                    Price = 14.0,
                                    Nummer = 20
                                },
                                new Alle_gerechten()
                                {
                                    Name = "21. Veg Burger",
                                    Price = 12.0,
                                    Nummer = 21
                                },
                                new Alle_gerechten()
                                {
                                    Name = "22. Vanilla ijs",
                                    Price = 3.0,
                                    Nummer = 22
                                },
                                new Alle_gerechten()
                                {
                                    Name = "23. crembule",
                                    Price = 6.0,
                                    Nummer = 23
                                },
                                new Alle_gerechten()
                                {
                                    Name = "24. Oreotaart",
                                    Price = 6.0,
                                    Nummer = 24
                                },
                                new Alle_gerechten()
                                {
                                    Name = "25. Gebakken banaantjes",
                                    Price = 7.0,
                                    Nummer = 25
                                },
                                new Alle_gerechten()
                                {
                                    Name = "26. crepe",
                                    Price = 2.0,
                                    Nummer = 26
                                },
                                new Alle_gerechten()
                                {
                                    Name = "27. dessert van de dag",
                                    Price = 14.0,
                                    Nummer = 27
                                },
                                new Alle_gerechten()
                                {
                                    Name = "28. warme koffie",
                                    Price = 12.0,
                                    Nummer = 28
                                },
                            };
                            var GerechtenJson = JsonConvert.SerializeObject(alle_gerechten);
                            File.WriteAllText(@"Alle_gerechten.json", GerechtenJson);

                            // Laat alle gerechten zien
                            foreach (Alle_gerechten g in alle_gerechten)
                            {
                                string display_A = $"| {g.Name}{drawString(50 - g.Name.Length, " ")}${g.Price}";
                                Console.WriteLine(display_A);

                            }

                        }
                        // Keuze maken welke gerechten hij/zij wilt.
                        else if (Choose_nummer1 == 2)
                        {
                            Console.Clear();
                            // Hij opent de text file leest alle file in een string en sluit de file
                            var json = @"C:\Users\kangb\source\repos\NieuwsteProjectB\kangyou's code\kangyou's code\Alle_Json_DATA\Gerechten_kiezen.json";
                            string Gerechten_lezen = File.ReadAllText(json);
                            // toegang tot je file deserialize.
                            var d = JsonConvert.DeserializeObject<Gerechten_kiezen>(Gerechten_lezen);
                            //var json_1 = @"C:\Users\kangb\source\repos\NieuwsteProjectB\kangyou's code\kangyou's code\DATA\jsconfig1.json";
                            //string Gerechten_lezen_1 = File.ReadAllText(json_1);
                            //var e = JsonConvert.DeserializeObject<Totaal_Bedrag>(Gerechten_lezen_1);

                            double Totaalprijs = 0;
                            string Overzicht_Gerechten = "";
                        Terug_naar_Nummer_1:
                            Console.WriteLine("Vul een gerecht nummer in : ");
                        Terug_naar_Nummer:
                            string Kiesnummer_1 = Console.ReadLine();

                            if (!int.TryParse(Kiesnummer_1, out int nummer))
                            {
                                Console.WriteLine("\n Probeer het opnieuw , vul een nummer in");
                                goto Terug_naar_Nummer_1;
                            }
                            else
                            {
                                int Naarint = Convert.ToInt32(Kiesnummer_1);
                                string ein_0 = "Naam : " + d.Name[0] + "\nPrice : " + d.Price[0];
                                string ein_1 = "Naam : " + d.Name[1] + "\nPrice : " + d.Price[1];
                                string ein_2 = "Naam : " + d.Name[2] + "\nPrice : " + d.Price[2];
                                string ein_3 = "Naam : " + d.Name[3] + "\nPrice : " + d.Price[3];
                                string ein_4 = "Naam : " + d.Name[4] + "\nPrice : " + d.Price[4];
                                string ein_5 = "Naam : " + d.Name[5] + "\nPrice : " + d.Price[5];
                                string ein_6 = "Naam : " + d.Name[6] + "\nPrice : " + d.Price[6];
                                string ein_7 = "Naam : " + d.Name[7] + "\nPrice : " + d.Price[7];
                                string ein_8 = "Naam : " + d.Name[8] + "\nPrice : " + d.Price[8];
                                string ein_9 = "Naam : " + d.Name[9] + "\nPrice : " + d.Price[9];
                                string ein_10 = "Naam : " + d.Name[10] + "\nPrice : " + d.Price[10];
                                string ein_11 = "Naam : " + d.Name[11] + "\nPrice : " + d.Price[11];
                                string ein_12 = "Naam : " + d.Name[12] + "\nPrice : " + d.Price[12];
                                string ein_13 = "Naam : " + d.Name[13] + "\nPrice : " + d.Price[13];
                                string ein_14 = "Naam : " + d.Name[14] + "\nPrice : " + d.Price[14];
                                string ein_15 = "Naam : " + d.Name[15] + "\nPrice : " + d.Price[15];
                                string ein_16 = "Naam : " + d.Name[16] + "\nPrice : " + d.Price[16];
                                string ein_17 = "Naam : " + d.Name[17] + "\nPrice : " + d.Price[17];
                                string ein_18 = "Naam : " + d.Name[18] + "\nPrice : " + d.Price[18];
                                string ein_19 = "Naam : " + d.Name[19] + "\nPrice : " + d.Price[19];
                                string ein_20 = "Naam : " + d.Name[20] + "\nPrice : " + d.Price[20];
                                string ein_21 = "Naam : " + d.Name[21] + "\nPrice : " + d.Price[21];
                                string ein_22 = "Naam : " + d.Name[22] + "\nPrice : " + d.Price[22];
                                string ein_23 = "Naam : " + d.Name[23] + "\nPrice : " + d.Price[23];
                                string ein_24 = "Naam : " + d.Name[24] + "\nPrice : " + d.Price[24];
                                string ein_25 = "Naam : " + d.Name[25] + "\nPrice : " + d.Price[25];
                                string ein_26 = "Naam : " + d.Name[26] + "\nPrice : " + d.Price[26];
                                string ein_27 = "Naam : " + d.Name[27] + "\nPrice : " + d.Price[27];

                                if (Naarint == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_0);
                                    Totaalprijs = Totaalprijs + d.Price[0];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[0] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;


                                }
                                else if (Naarint == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_1);
                                    Totaalprijs = Totaalprijs + d.Price[1];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[1] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;

                                }
                                else if (Naarint == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_2);
                                    Totaalprijs = Totaalprijs + d.Price[2];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[2] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;

                                }
                                else if (Naarint == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_3);
                                    Totaalprijs = Totaalprijs + d.Price[3];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[3] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;

                                }
                                else if (Naarint == 5)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_4);
                                    Totaalprijs = Totaalprijs + d.Price[4];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[4] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;

                                }
                                else if (Naarint == 6)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_5);
                                    Totaalprijs = Totaalprijs + d.Price[5];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[5] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 7)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_6);
                                    Totaalprijs = Totaalprijs + d.Price[6];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[6] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 8)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_7);
                                    Totaalprijs = Totaalprijs + d.Price[7];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[7] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 9)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_8);
                                    Totaalprijs = Totaalprijs + d.Price[8];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[8] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 10)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_9);
                                    Totaalprijs = Totaalprijs + d.Price[9];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[9] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 11)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_10);
                                    Totaalprijs = Totaalprijs + d.Price[10];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[10] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 12)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_11);
                                    Totaalprijs = Totaalprijs + d.Price[11];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[11] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 13)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_12);
                                    Totaalprijs = Totaalprijs + d.Price[12];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[12] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 14)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_13);
                                    Totaalprijs = Totaalprijs + d.Price[13];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[13] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 15)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_14);
                                    Totaalprijs = Totaalprijs + d.Price[14];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[14] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 16)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_15);
                                    Totaalprijs = Totaalprijs + d.Price[15];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[15] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 17)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_16);
                                    Totaalprijs = Totaalprijs + d.Price[16];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[16] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 18)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_17);
                                    Totaalprijs = Totaalprijs + d.Price[17];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[17] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 19)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_18);
                                    Totaalprijs = Totaalprijs + d.Price[18];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[18] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 20)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_19);
                                    Totaalprijs = Totaalprijs + d.Price[19];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[19] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 21)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_20);
                                    Totaalprijs = Totaalprijs + d.Price[20];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[20] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 22)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_21);

                                    Totaalprijs = Totaalprijs + d.Price[21];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[21] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 23)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_22);
                                    Totaalprijs = Totaalprijs + d.Price[22];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[22] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 24)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_23);
                                    Totaalprijs = Totaalprijs + d.Price[23];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[23] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 25)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_24);
                                    Totaalprijs = Totaalprijs + d.Price[24];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[24] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 26)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_25);
                                    Totaalprijs = Totaalprijs + d.Price[25];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[25] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 27)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_26);
                                    Totaalprijs = Totaalprijs + d.Price[26];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[26] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else if (Naarint == 28)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ein_27);
                                    Totaalprijs = Totaalprijs + d.Price[27];
                                    Overzicht_Gerechten = Overzicht_Gerechten + d.Name[27] + "\n";
                                    Console.WriteLine("\n\nOverzicht = \n\n\n" + Overzicht_Gerechten);
                                    Console.WriteLine("\n\n\n\ntotaalprijs = " + Totaalprijs);
                                    Console.WriteLine("\n\n\n\nKies [1] voor meer gerechten toevoegen");
                                    Console.WriteLine("Kies [2] om verder te gaan met reserveren\n\n");
                                    Console.WriteLine("Kies de gerecht nummer : ");
                                    goto Terug_naar_Nummer;
                                }
                                else
                                {
                                    Console.WriteLine("Kies tussen de nummers 1 en 28 !!!!");
                                    goto Terug_naar_Nummer_1;
                                }


                            }
                        }
                    }
                    Console.WriteLine("\n\n\nType b om terug te gaan");
                    string Back_1 = Console.ReadLine();
                    if (Back_1 == "b")
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
                    Console.WriteLine("\n  Nummer mislukt,  Kies tussen de nummers [1] , [2] -, [3] - [4] - [5]");
                    goto dot;
                }
            }

        }
    }

}