using System.Globalization;

namespace Part2

{
    static class Program
    {
        static void Main()
        {
            klant_ID:
            Console.Write("Klant id: ");
            // Invoer lezen
            string klant_ID = Console.ReadLine()!;

            // Als de klant-ID niet int is of negatief is, wordt er een fout weergegeven
            if (!int.TryParse(klant_ID, out var fixedKlantID) || fixedKlantID < 0)
            {
                Console.WriteLine("Klant id is ongeldig! Voer uw klant id opnieuw in.");
                goto klant_ID;
            }

            tafel_ID:
            Console.Write("Tafel id: ");
            // Reading input
            string tafel_ID = Console.ReadLine()!;

            // Als de tafel_ID niet int is of negatief is of groter is dan 15 (we hebben 15 tafel's met id's van 1 tot 15]), geven we een fout weer
            if (!int.TryParse(tafel_ID, out var fixedTafelID) || fixedTafelID < 0 || fixedTafelID > 14)
            {
                Console.WriteLine("Tafel id is ongeldig! Voer uw tafel id opnieuw in.");
                goto tafel_ID;
            }

            aantal_Personen:
            Console.Write("Aantal personen: ");
            string aantal_Personen = Console.ReadLine()!;

            // Als aantal Personen niet int is of negatief is of 0 is, geven we een fout weer
            if (!int.TryParse(aantal_Personen, out var fixedAantalPersonen) || fixedAantalPersonen <= 0)
            {
                Console.WriteLine("Klant id is ongeldig! Voer het aantal personen opnieuw in.");
                goto aantal_Personen;
            }

            // Als we proberen een tafel te reserveren voor meer dan 8 personen,
            // geven we informatie weer die we nodig hebben om contact op te nemen met de reservering
            if (fixedAantalPersonen > 8)
            {
                Console.WriteLine("Om een tafel voor meer personen te reserveren moet u contact opnemen met het restaurant!\n\nVoer het aantal personen opnieuw in.");
                goto aantal_Personen;
            }

            datum:
            Console.Write("Datum van reservering inclusief tijd(dd/MM/yyyy HH:mm): ");
            string date = Console.ReadLine()!;

            //We proberen de tekenreeks in het opgegeven formaat tot de datum en tijd te ontleden
            //en controleren of deze datum is gebeurd
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime fixedDate) || fixedDate < DateTime.Today)
            {
                // als dat zo is, geven we een fout weer
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Onjuiste datum! Voer uw datum opnieuw in.");
                Console.BackgroundColor = ConsoleColor.Black;
                // and go back to date label
                goto datum;
            }
            // Controleer de datum van de week van de opgegeven datum
            if (fixedDate.DayOfWeek == DayOfWeek.Sunday || fixedDate.DayOfWeek == DayOfWeek.Saturday)
            {
                // Als het zaterdag of zondag is, controleren we de werktijden voor het weekend
                if (fixedDate.TimeOfDay < new TimeSpan(11, 30, 0) || fixedDate.TimeOfDay > new TimeSpan(23, 0, 0))
                {
                    // We geven een fout weer
                    Console.WriteLine("De reserveringstijd valt buiten de openingstijden van het restaurant. Voer uw datum opnieuw in.");
                    goto datum;
                }
            }
            else
            {
                // Als het niet zaterdag of zondag is, controleren we de werktijden voor ma-vr
                if (fixedDate.TimeOfDay < new TimeSpan(10, 00, 0) || fixedDate.TimeOfDay > new TimeSpan(20, 0, 0))
                {
                    Console.WriteLine("De reserveringstijd valt buiten de openingstijden van het restaurant. Voer uw datum opnieuw in.");
                    goto datum;
                }
            }

            // Betalingsmiddel
            bool repeat = true;
            while (repeat)
            {
                // Display menu
                Console.WriteLine("1 - iDeal");
                Console.WriteLine("2 - Debit/Credit card");
                Console.Write("Klik op de knop om verder te gaan: ");
                // Read key
                switch (Console.ReadKey().Key)
                {
                    // Als de ingedrukte toets 1 of 2 is, stoppen we de lus
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                        repeat = false;
                        break;
                    default:
                        //Als er geen fout werd weergegeven
                        Console.WriteLine();
                        Console.WriteLine("Voer een van de hierboven vermelde nummers in. ");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine();

            // Proberen tafel te reserveren
            if (!ReservationSystem.Reserve(fixedKlantID, fixedTafelID, fixedAantalPersonen, fixedDate))
            {
                // Als het niet mogelijk is omdat de tafel deze keer bezet is, geven we een fout weer
                Console.WriteLine("Deze tafel is gereserveerd op dit uur!");
                return;
            }

            // Als de reservering is gelukt, wordt er een bericht over weergegeven
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSuccesvol gereserveerde tafel.");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
