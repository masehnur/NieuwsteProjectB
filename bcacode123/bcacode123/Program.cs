using System;

public class Program
{
    public static void Main()
    {
        // Voorpagina met variabeles
        var page = 0;
        var Vooraf = "1";
        var Achteraf = "2";
        var gaTerug = "0";
        while (page == 0)
        {
            // Wanneer willen ze betalen
            Console.WriteLine("Betaalt u liever vooraf of achteraf?.\n[0] Terug\n[1] Vooraf\n[2] Achteraf\n");
            var wanneer = Console.ReadLine();
            if (wanneer == Achteraf)
            {
                // wanneer achteraf wordt gekozen
                Console.WriteLine("\nU kunt achteraf met VISA, Mastercard, Ideal of contant betalen.\n[0] Terug\n");
                page = 1;
                if (Console.ReadLine() == gaTerug)
                {
                    page = 0;
                }
            }
            if (wanneer == Vooraf)
            {
                // Met welke pas willen ze betalen
                page = 1;
                Console.WriteLine("Toets uw betaalmethode.\n[0] Terug\n[1] IDEAL\n[2] VISA\n[3] Mastercard\n");
                var methode = Console.ReadLine();
                if (methode == "1")
                {
                    Console.WriteLine("Toets uw bank met de onderstaande keuzes.\n[0] Terug\n[1] ABN AMRO\n[2] ING\n[3] RABO\n");
                    var bankInput = Console.ReadLine();
                    // bankopties
                    if (bankInput == "1" || bankInput == "2" || bankInput == "3")
                    {
                        Console.WriteLine("Klik op 'Betalen' om door te gaan naar uw bank-app.");
                        Console.WriteLine("Toets '0' als u terug wilt gaan.\n[0] Terug");
                        var teruggaan = Console.ReadLine();
                         if (teruggaan == "0")
                        {
                            page = 0;
                        }
                        
                    }
                    else if (bankInput == "0")
                    {
                        page = 0;
                    }
                    else
                    {
                        Console.WriteLine("Verkeerde input, probeer nogmaals.\n");
                        page = 0;
                    }

                }
                // geen ideal
                else if (methode == "2" || methode == "3")
                {
                    page = 2;
                    while (page == 2)
                    {
                        double cardNumber;
                        double pin;
                        DateTime datum;
                        Console.WriteLine("Voer uw kaartnummer in.");
                        while (true)
                        {
                            while (!double.TryParse(Console.ReadLine(), out cardNumber))
                            {
                                Console.Write("Voer alleen nummers in. Probeer nogmaals.\n");
                            }
                            if ((cardNumber.ToString()).Length != 16)
                            {
                                Console.Write("De ingevoerde kaartnummer is geen 16 getallen. Probeer nogmaals.\n");
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.WriteLine("Tot wanneer is het geldig?");


                        Console.WriteLine("DATUM MM-YYYY");
                        while (true)
                        {
                            while (!DateTime.TryParseExact(Console.ReadLine(), "M-yyyy", null, System.Globalization.DateTimeStyles.None, out datum))
                            {
                                Console.Write("Alleen een datum in het formaat MM-YYYY is toegestaan. Probeer nogmaals.\n");
                            }
                            if (((datum.Year < DateTime.Now.Year) || (datum.Year == DateTime.Now.Year) && (datum.Month < DateTime.Now.Month)) || datum.Year > (DateTime.Now.Year + 3))
                            {
                                Console.Write("Voer alsjeblieft een geldig jaar en maand in. Probeer nogmaals.\n");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine("Voer uw Pin in.");
                        while (true)
                        {
                            while (!double.TryParse(Console.ReadLine(), out pin))
                            {
                                Console.Write("Voer alleen nummers in. Probeer nogmaals.\n");
                            }
                            if ((pin.ToString()).Length != 4)
                            {
                                Console.Write("De ingevoerde Pin moet uit vier getallen bestaan. Probeer nogmaals.\n");
                            }
                            else
                            {
                                break;
                            }
                        }
                        page = 1;
                        Console.WriteLine("Voordat u betaalt, wilt u terug naar het hoofdmenu?\n[0] Ja\n[1] Nee, ik wil betalen");
                        var bevestig = Console.ReadLine();
                        if (bevestig == "0")
                        {
                            page = 0;
                        }
                        else if (bevestig == "1")
                        {
                            Console.WriteLine("Te weinig saldo");
                        }
                        
                    }

                }
                else
                {
                    Console.WriteLine("Verkeerde input, probeer nogmaals.\n");
                    page = 0;
                }


            }
        }
    }
}
