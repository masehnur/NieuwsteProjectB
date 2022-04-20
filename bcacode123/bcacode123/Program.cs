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
                    Console.WriteLine("Klik op 'Betalen' voor verdere instructies.");
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