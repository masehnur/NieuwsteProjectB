using Gegevens;
using System.ComponentModel.DataAnnotations;

namespace Reservering
{
    static class Program
    {
        static void Main()
        {
            // Menu loop
            while (true)
            {
                // Menu weergeven
                Console.Clear();
                Console.WriteLine("\t\t\t--<<<Welkom in ons restaurant>>>--\n");
                Console.WriteLine("\t\t 1 - Registeren");
                Console.WriteLine("\t\t 2 - Inloggen");
                Console.WriteLine("\t\t 3 - Verder als gast");
                Console.WriteLine("\t\t 4 - Informatie");
                Console.Write("\nVoer een van de bovenstaande nummers in: ");

                // Sleutel invoer lezen           
                switch (Console.ReadKey().Key)
                {
                    #region 1
                    case ConsoleKey.D1:
                        Console.WriteLine();

                        email:
                        Console.Write("\nE-mail: ");
                        string email1 = Console.ReadLine()!;

                        // Als e-mail niet geldig is, geven we een fout weer
                        if (!new EmailAddressAttribute().IsValid(email1))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Onjuiste e-mail! Voer uw e-mail opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto email;
                        }

                        naam:
                        Console.Write("\nNaam: ");
                        string naam = Console.ReadLine()!;

                        // als de naam korter is dan 3 tekens, geven we een fout weer
                        if (naam.Length < 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Te korte naam! Voer uw naam opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto naam;
                        }

                        // als de naam niet alleen letters bevat, geven we een fout weer
                        if (!naam.All(char.IsLetter))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Een naam mag alleen letters bevatten! Voer uw naam opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto naam;
                        }

                        Achternaam:
                        Console.Write("\nAchternaam: ");
                        string Achternaam = Console.ReadLine()!;

                        // als de achternaam korter is dan 3 tekens, geven we een fout weer
                        if (Achternaam.Length < 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Te korte achternaam! Voer uw achternaam opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Achternaam;
                        }

                        // als achternaam niet alleen letters bevat, geven we een fout weer
                        if (!Achternaam.All(char.IsLetter))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Een achternaam mag alleen letters bevatten! Voer uw naam opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Achternaam;
                        }

                        Geboortedatum:
                        Console.Write("\nGeboortedatum: ");
                        string birthDate1 = Console.ReadLine()!;

                       
                        // Als de opgegeven datumreeks geen geldige datum is of de geparseerde datum niet is gebeurd, geven we een fout weer
                        if (!DateTime.TryParse(birthDate1, out DateTime fixedDate1) || fixedDate1 >= DateTime.Today)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Onjuiste datum! Voer uw Geboortedatum opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Geboortedatum;
                        }
                        
                        // als het verschil met vandaag en de opgegeven datum kleiner is dan 16 jaar, geven we een fout weer
                        if (DateTime.Today.Subtract(fixedDate1).TotalDays / 365.2425 < 16)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Je moet 16 jaar oud zijn om je in te schrijven! Voer uw Geboortedatum opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Geboortedatum;
                        }
                       
                        // als het verschil met vandaag en de opgegeven datum groter is dan 106 jaar, geven we een fout weer
                        if (DateTime.Today.Subtract(fixedDate1).TotalDays / 365.2425 > 106)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Leeftijd is onlogisch! Voer uw Geboortedatum opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Geboortedatum;
                        }
                    Telefoonnummer:
                        Console.Write("\nTelefoonnummer: ");
                        string phone = Console.ReadLine()!;

                        // Lezen input
                        // als het opgegeven telefoonnummer niet geldig is of korter is dan 8 of langer dan 14 tekens, wordt er een fout weergegeven
                        if (!new PhoneAttribute().IsValid(phone) || phone.Length < 8 || phone.Length > 14)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Onjuiste telefoonnummer! Voer uw phone opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Telefoonnummer;
                        }

                        Wachtwoord:
                        Console.Write("\nWachtwoord: ");
                        string password1 = Console.ReadLine()!;

                        // als het wachtwoord korter is dan 6 tekens, geven we een fout weer
                        if (password1.Length < 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Te korte wachtwoord! Voer uw wachtwoord opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Wachtwoord;
                        }

                        Herhaal_Wachtwoord:
                        Console.Write("\nHerhaal Wachtwoord: ");
                        string repeatedPassword = Console.ReadLine()!;

                       // als het herhaalde wachtwoord niet hetzelfde is als het oorspronkelijke wachtwoord, geven we een fout weer
                        if (password1 != repeatedPassword)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wachtwoorden zijn niet hetzelfde! Voer uw herhaal wachtwoord opnieuw in.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto Herhaal_Wachtwoord;
                        }
                        Console.WriteLine();

                        // Als de poging om te registreren mislukt, vanwege hetzelfde e-mailadres als het e-mailadres van bestaande accounts, geven we een fout weer
                        if (!LoginSystem.Register(email1, naam, Achternaam, fixedDate1, phone, password1))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Een account met dit e-mailadres bestaat al!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            return;
                        }

                        // als de registratiepoging succesvol is, wordt er een bericht over weergegeven
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Succesvol geregistreerd!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        return;
                    #endregion 1

                    #region 2
                    case ConsoleKey.D2:
                        Console.WriteLine();

                        Email:
                        Console.Write("E-mail: ");
                        string email = Console.ReadLine()!;

                        // Lezen input
                        Console.Write("Wachtwoord: ");
                        string password2 = Console.ReadLine()!;

                        
                        // Als het account met het opgegeven e-mailadres niet bestaat of het wachtwoord onjuist is, wordt er een fout weergegeven
                        if (!LoginSystem.Login(email, password2))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Onjuiste inloggegevens!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            //  return;
                            goto Email;
                        }

                        // Als de inlogpoging succesvol is, wordt er een bericht over weergegeven
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Succesvol ingelogd!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        return;
                    #endregion 2


                    #region 3
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        date2:
                        Console.Write("Geboortedatum: ");
                        string birthDate2 = Console.ReadLine()!;

                        // Als de opgegeven datumreeks geen geldige datum is of de geparseerde datum niet is gebeurd, geven we een fout weer
                        if (!DateTime.TryParse(birthDate2, out DateTime fixedDate2) || fixedDate2 >= DateTime.Today)
                        {
                            Console.WriteLine("Onjuiste datum! Voer uw Geboortedatum opnieuw in.");
                            goto date2;
                        }

                        // als het verschil met vandaag en de opgegeven datum kleiner is dan 16 jaar, geven we een fout weer
                        if (DateTime.Today.Subtract(fixedDate2).TotalDays / 365.2425 < 16)
                        {
                            Console.WriteLine("Je moet 16 jaar oud zijn om als gast binnen te komen! Voer uw Geboortedatum opnieuw in.");
                            goto date2;
                        }

                        // als de gebruiker ten minste 16 jaar oud is, geven we aan dat hij succesvol als gast is binnengekomen
                        Console.WriteLine("Je kwam binnen als een gast.");
                        return;
                    #endregion 3

                    #region 4
                    case ConsoleKey.D4:

                        // informatie weergeven over werkuren en contact met restaurant
                        Console.WriteLine();
                        Console.WriteLine("\nInformatie");
                        Console.WriteLine();
                        Console.WriteLine("  Openingstijden:");
                        Console.WriteLine("  >> ma-vr 10:00-20:00");
                        Console.WriteLine("  >> za/zo 11:30-23:00");
                        Console.WriteLine();
                        Console.WriteLine("  Contact:");
                        Console.WriteLine("  >> 010-1234567");
                        Console.WriteLine("  >> RestaurantProjectB@gmail.com");
                        Console.WriteLine("  >> Wijnhaven 107, 3011 WN Rotterdam");
                        return;
                    #endregion 4

                    default:
                       // als de ingevoerd nummer niet 1 of 2 of 3 of 4 is, geven we een fout weer
                        Console.WriteLine();
                        Console.WriteLine("Voer een van de hierboven vermelde nummers in. ");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
