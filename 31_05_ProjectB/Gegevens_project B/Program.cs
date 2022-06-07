using System.Globalization;
using Gegevens;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static Program.cs.Program;

namespace Reservering
{
    static class Program
    {

        static void Main()
        #region 0
        {
        Start_point:
            //menu/inloggen/registreren/verder als gast
            #region 1

            // Menu weergeven
            Console.Clear();
            Console.WriteLine("\t\t\t--<<<Welkom in ons restaurant>>>--\n");
            Console.WriteLine("\t\t 1 - Registeren");
            Console.WriteLine("\t\t 2 - Inloggen");
            Console.WriteLine("\t\t 3 - Verder als gast");
            Console.WriteLine("\t\t 4 - Informatie");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nVoer een van de bovenstaande nummers in: ");
            Console.ResetColor();

            // Sleutel invoer lezen
            string Start1 = Console.ReadLine()!;
            if (Start1 == "1")
            {
            email:
             
               // string email1 = Console.ReadLine()!;

                Console.Write("Enter Your Email: ");
                string email1 = Console.ReadLine()!;
                Regex reg = new Regex(@"^\w+([-_•]\w+)*@\w+([-•]\w+)*\.\w+([-.]\w+)*$");
                if (! reg.IsMatch(email1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Onjuiste e-mail! Voer uw e-mail opnieuw in.");
                    Console.ResetColor();
                    goto email;
                }

            naam:
                Console.Write("\nNaam: ");
                string naam = Console.ReadLine()!;

                // als de naam korter is dan 3 tekens, geven we een fout weer
                if (naam.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te korte naam! Voer uw naam opnieuw in.");
                    Console.ResetColor();
                    goto naam;
                }

                // als de naam niet alleen letters bevat, geven we een fout weer
                if (!naam.All(char.IsLetter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Een naam mag alleen letters bevatten! Voer uw naam opnieuw in.");
                    Console.ResetColor();
                    goto naam;
                }

            Achternaam:
                Console.Write("\nAchternaam: ");
                string Achternaam = Console.ReadLine()!;

                // als de achternaam korter is dan 3 tekens, geven we een fout weer
                if (Achternaam.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te korte achternaam! Voer uw achternaam opnieuw in.");
                    Console.ResetColor();
                    goto Achternaam;
                }

                // als achternaam niet alleen letters bevat, geven we een fout weer
                if (!Achternaam.All(char.IsLetter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Een achternaam mag alleen letters bevatten! Voer uw achternaam opnieuw in.");
                    Console.ResetColor();
                    goto Achternaam;
                }

            Geboortedatum:
                Console.Write("\nGeboortedatum (dd-mm-jjjj): ");
                string birthDate1 = Console.ReadLine()!;


                // Als de opgegeven datumreeks geen geldige datum is of de geparseerde datum niet is gebeurd, geven we een fout weer
                if (!DateTime.TryParse(birthDate1, out DateTime fixedDate1) || fixedDate1 >= DateTime.Today)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Onjuiste datum! Voer uw Geboortedatum opnieuw in.");
                    Console.ResetColor();
                    goto Geboortedatum;
                }

                // als het verschil met vandaag en de opgegeven datum kleiner is dan 16 jaar, geven we een fout weer
                if (DateTime.Today.Subtract(fixedDate1).TotalDays / 365.24 < 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Je bent {Math.Floor(DateTime.Today.Subtract(fixedDate1).TotalDays / 365.24)} jaar. " +
                                      $"Je moet 16 jaar oud zijn om je in te schrijven! Voer uw Geboortedatum opnieuw in.");
                    Console.ResetColor();
                    goto Geboortedatum;
                }

                // als het verschil met vandaag en de opgegeven datum groter is dan 106 jaar, geven we een fout weer
                if (DateTime.Today.Subtract(fixedDate1).TotalDays / 365.2425 > 106)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Leeftijd is onlogisch! Voer uw Geboortedatum opnieuw in.");
                    Console.ResetColor();
                    goto Geboortedatum;
                }
            Telefoonnummer:
                Console.Write("\nTelefoonnummer: ");
                string phone = Console.ReadLine()!;

                // als het opgegeven telefoonnummer niet geldig is 10 nummers, wordt er een fout weergegeven
                if (!new PhoneAttribute().IsValid(phone) || phone.Length != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Onjuist telefoonnummer! Voer uw telefoonnummer opnieuw in.");
                    Console.ResetColor();
                    goto Telefoonnummer;
                }

            Wachtwoord:
                Console.Write("\nWachtwoord: ");
                string password1 = Console.ReadLine()!;

                // als het wachtwoord korter is dan 6 tekens, geven we een fout weer
                if (password1.Length < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te korte wachtwoord! Wachtwoord moet minimaal 6 tekens lang zijn. Voer uw wachtwoord opnieuw in.");
                    Console.ResetColor();
                    goto Wachtwoord;
                }

            Herhaal_Wachtwoord:
                Console.Write("\nHerhaal Wachtwoord: ");
                string repeatedPassword = Console.ReadLine()!;

                // als het herhaalde wachtwoord niet hetzelfde is als het oorspronkelijke wachtwoord, geven we een fout weer
                if (password1 != repeatedPassword)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wachtwoorden zijn niet hetzelfde! Voer uw herhaal wachtwoord opnieuw in.");
                    Console.ResetColor();
                    goto Herhaal_Wachtwoord;
                }
                Console.WriteLine();

                // Als de poging om te registreren mislukt, vanwege hetzelfde e-mailadres als het e-mailadres van bestaande accounts, geven we een fout weer
                if (!LoginSystem.Register(email1, naam, Achternaam, fixedDate1, phone, password1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Een account met dit e-mailadres bestaat al!");
                    Console.ResetColor();
                    return;
                }

                // als de registratiepoging succesvol is, wordt er een bericht over weergegeven
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccesvol geregistreerd!\n");
                Console.ResetColor();
                Hoofdmenu();
                return;
            }
            else if (Start1 == "2")
            {


                Console.WriteLine();
                int poging = 3;

            Email:
                while (poging > 0)
                {
                    Console.Write("E-mail: ");
                    string email = Console.ReadLine()!;
                    // Als e-mail niet geldig is, geven we een fout weer
                    if (!new EmailAddressAttribute().IsValid(email))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Onjuiste e-mail! Voer uw e-mail opnieuw in.");
                        Console.ResetColor();
                        goto Email;
                    }

                    // Lezen input
                    Console.Write("Wachtwoord: ");
                    string password2 = Console.ReadLine()!;


                    // Als het account met het opgegeven e-mailadres niet bestaat of het wachtwoord onjuist is,
                    // wordt er een fout weergegeven
                    if (!LoginSystem.Login(email, password2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Onjuiste inloggegevens!");
                        Console.ResetColor();
                        poging--;


                        if (poging == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInlogpogingen zijn uitgeput.\n" +
                                "Neem contact op met het restaurant als u uw wachtwoord bent vergeten." +
                                "\n\tTot ziens!");
                            Console.ResetColor();
                            goto Email;
                        }
                    }


                    else
                    {
                        // Als de inlogpoging succesvol is, wordt er een bericht over weergegeven
                        poging = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Succesvol ingelogd!\n");
                        Console.ResetColor();

                        Hoofdmenu();
                    }
                }
                return;
            }
            else if (Start1 == "3")
            {
                Console.WriteLine();

            date2:
                Console.Write("Geboortedatum(dd-mm-jjjj): ");
                string birthDate2 = Console.ReadLine()!;

                // Als de opgegeven datumreeks geen geldige datum is of de geparseerde datum niet is gebeurd, geven we een fout weer
                if (!DateTime.TryParse(birthDate2, out DateTime fixedDate2) || fixedDate2 >= DateTime.Today)

                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Onjuiste datum! Voer uw Geboortedatum opnieuw in.");
                    Console.ResetColor();
                    goto date2;
                }

                // als het verschil met vandaag en de opgegeven datum kleiner is dan 16 jaar, geven we een fout weer
                if (DateTime.Today.Subtract(fixedDate2).TotalDays / 365.2425 < 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Je bent {Math.Floor(DateTime.Today.Subtract(fixedDate2).TotalDays / 365.24)} jaar." +
                                   $"Je moet 16 jaar oud zijn om als gast binnen te komen! Voer uw Geboortedatum opnieuw in.");
                    Console.ResetColor();
                    goto date2;
                }
                // als het verschil met vandaag en de opgegeven datum groter is dan 106 jaar, geven we een fout weer
                if (DateTime.Today.Subtract(fixedDate2).TotalDays / 365.2425 > 106)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Leeftijd is onlogisch! Voer uw Geboortedatum opnieuw in.");
                    Console.ResetColor();
                    goto date2;
                }

                // als de gebruiker ten minste 16 jaar oud is, geven we aan dat hij succesvol als gast is binnengekomen
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Je kwam binnen als een gast.\n");
                Console.ResetColor();
                Hoofdmenu();
                return;

            }
            else if (Start1 == "4")
            {

                var Contactgegevens = Tuple.Create("  Openingstijden:", "  >> ma-vr 10:00-20:00", "  >> za/zo 11:30-20:00", "  >> 010-1234567",
                    "  >> RestaurantProjectB@gmail.com", "  >> Wijnhaven 107, 3011 WN Rotterdam", "\nKlik op een ster om terug naar het hoofdmenu.");
                Console.WriteLine($"\nInformatie \n\n{ Contactgegevens.Item1}\n{ Contactgegevens.Item2}\n{ Contactgegevens.Item3}\n");
                Console.WriteLine($"  Contact: \n{ Contactgegevens.Item4}\n{ Contactgegevens.Item5}\n{ Contactgegevens.Item6}");

            Info:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n  [*] Terug");
                Console.ResetColor();
                string go_start = Console.ReadLine()!;
                if (go_start == "*")
                {
                    Console.Clear();
                    goto Start_point;
                }
                else
                {
                    goto Info;
                }

            }

            else
            {
                // als de ingevoerd nummer niet 1 of 2 of 3 of 4 is, geven we een fout weer

                goto Start_point;
            }

        }

            #endregion 1
            //hoofdmenu
            #region 2
            static void Hoofdmenu()
            {

            Startpoint: Console.WriteLine("\n****Hoofdmenu****\n");
                
                Console.WriteLine("1- Reserveren. \n2- Reserveren en vooraf bestellen. \n3- algemene informatie.\n\n-Voer een van de bovenstaande nummers in: \n ");
                string Start ;
                Start = Console.ReadLine()!;
                if (Start == "1")
                {
                    Console.Clear();
                    Reserveren();

                }
                else if (Start == "2")
                {
                    Console.Clear();
                    Menu();
                    string gostart = Console.ReadLine()!;
                    if (gostart == "*")
                    {
                        Console.Clear();
                        goto Startpoint;
                    }
                    else { Console.WriteLine($"\n  [*] Terug"); }
                }

                else if (Start == "3")
                {
                    Console.Clear(); ;
                    var Contactgegevens = Tuple.Create("  Openingstijden:", "  >> ma-vr 10:00-20:00", "  >> za/zo 11:30-20:00", "  >> 010-1234567", "  >> RestaurantProjectB@gmail.com", "  >> Wijnhaven 107, 3011 WN Rotterdam", "\nKlik op een ster om terug naar het hoofdmenu.");
                    Console.WriteLine($"\nInformatie \n\n{ Contactgegevens.Item1}\n{ Contactgegevens.Item2}\n{ Contactgegevens.Item3}\n");
                    Console.WriteLine($"  Contact: \n{ Contactgegevens.Item4}\n{ Contactgegevens.Item5}\n{ Contactgegevens.Item6}");
                    Console.WriteLine($"\n  [*] Terug");
                
                Vraag:
                    string gostart = Console.ReadLine()!;
                    if (gostart == "*")
                    {
                        Console.Clear();
                        goto Startpoint;
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\n  [*] Terug");
                        Console.ResetColor();
                        goto Vraag;
                    }
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nU heeft een ongeldige waarde ingetypt.\n");
                    Console.ResetColor();
                    goto Startpoint;

                }
            }
        
        #endregion 2

        //reserveren
        #region 4
            static void Reserveren()
            {
                Console.Clear();
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bookings.json"); //bestand naam en pad om json op te slaan
                Booking[,] Tables = new Booking[4, 4]; //2D array
                DateTime BookingDate = new DateTime(); //reserverings datum
                DateTime BookingTime = new DateTime(); //reserverings tijd

                //blijf vragen naar reserveringsdatum tot een geldige datum is ingevuld          
                while (true)
                {
                    Console.WriteLine("Voor wanneer wilt u reserveren? (jjjj-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out BookingDate)) //converten naar daytime object
                    {
                        DateTime cd = DateTime.Now; //huidige date
                    if ((cd - BookingDate).TotalDays > 0) //als huidige of eerdere datum is ingevuld
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Onjuiste reserverings datum.");
                        Console.ResetColor();
                    }
                    else if ((BookingDate - cd).TotalDays > 90) //als een datum is ingevuld dat meer dan 90 dagen verder is
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("U kunt alleen tot 90 dagen vooraf reserveren.");
                        Console.ResetColor();
                    }
                    else //als datum goed is dan break
                        break;
                    }
                }

                //blijf vragen om boekingstijd totdat de gebruiker een geldige tijd aangeeft 
                while (true)
                {
                    DayOfWeek bookingDOW = BookingDate.DayOfWeek; //boeking tijd van week
                    TimeSpan tsOpenTime = new TimeSpan(10, 0, 0); //openingstijden restaurant
                    TimeSpan tsCloseTime = new TimeSpan(20, 0, 0); //sluitingstijden restaurant
                    if (bookingDOW == DayOfWeek.Saturday || bookingDOW == DayOfWeek.Sunday) //weekend tijden anders
                        tsOpenTime = new TimeSpan(11, 30, 0);

                    //laat de dag van de week zien en de openings en sluitingstijden
                    Console.WriteLine("\nDatum dag: " + bookingDOW.ToString());
                    Console.WriteLine("Openingstijden: " + tsOpenTime.Hours + ":" + tsOpenTime.Minutes);
                    Console.WriteLine("Sluitingstijden: " + tsCloseTime.Hours + ":" + tsCloseTime.Minutes);
                    //vraag om de reserveringstijd
                    Console.WriteLine("\nLet op u kunt niet na 18:30 reserveren, kies uw reserveringstijd (uu:mm): ");
                    string strBTime = Console.ReadLine()!;
                    //check of het een geldige tijd is
                    bool valid = false;
                    string[] sparts = strBTime.Split(':');
                    if (sparts.Length == 2)
                    {
                        //uren en minuten
                        int hours = Convert.ToInt32(sparts[0]);
                        int minutes = Convert.ToInt32(sparts[1]);
                        //of tijd klopt
                        if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                        {
                            BookingTime = new DateTime(1, 1, 1, hours, minutes, 0);
                            valid = true;
                        }
                    }
                    if (valid)
                    {
                        //check of de reserveringstijd valt binnen de openingstijden
                        TimeSpan tsBookingStart = new TimeSpan(BookingTime.Hour, BookingTime.Minute, 0);
                        TimeSpan tsBookingEnd = tsBookingStart.Add(new TimeSpan(1, 30, 0));
                    if (!(tsBookingStart >= tsOpenTime && tsBookingStart <= tsCloseTime && tsBookingEnd >= tsOpenTime && tsBookingEnd <= tsCloseTime))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("U kunt niet reserveren omdat de geselecteerde tijd niet binnen de openingstijden vallen.");
                        Console.ResetColor();
                    }
                    else //als het goed is dan break
                        break;
                    }
                }

                //bouwen van de datetime variable
                DateTime BookingDateTime = new DateTime(BookingDate.Year, BookingDate.Month, BookingDate.Day, BookingTime.Hour, BookingTime.Minute, 0); //booking date string

                //json bookings
                List<Booking> bookings = new List<Booking>();
                if (File.Exists(file))
                    bookings = JsonConvert.DeserializeObject<List<Booking>>(File.ReadAllText(file))!;

                //laat tafel bookings zien
                Console.WriteLine("Reserveringen op " + BookingDateTime.ToString());
                Console.WriteLine("Tafel nummers met een blauwe achtergrond zijn bezet.");
                Console.WriteLine("Tafel nummers met een zwarte achtergrond zijn beschikbaar.");

                //laat een 2D array van de tafels zien
                int tableNo = 1;
                for (int row = 0; row <= 3; row++)
                {
                    for (int col = 0; col <= 3; col++)
                    {
                        //check of de tafel bezet is
                        bool booked = false;
                        foreach (Booking booking in bookings)
                        {
                            if (booking.BookingDateTime.ToString("yyyy-MM-dd") == BookingDateTime.ToString("yyyy-MM-dd")) //date hetzelfde
                            {
                                //tijd hetzelfde
                                TimeSpan tsStart = new TimeSpan(booking.BookingDateTime.Hour, booking.BookingDateTime.Minute, 0);
                                TimeSpan tsEnd = tsStart.Add(new TimeSpan(1, 30, 0));
                                TimeSpan tsBooking = new TimeSpan(BookingDateTime.Hour, BookingDateTime.Minute, 0);
                                if (tsBooking >= tsStart && tsBooking <= tsEnd && tableNo == booking.TableNo)
                                {
                                    booked = true;
                                    break;
                                }
                            }
                        }
                        //kleuren voor geboekte en ongeboekte tafels
                        if (booked)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(tableNo);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(tableNo);
                        }

                        //herstel kleuren
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\t");

                        //sla op in tafels array
                        Booking newBooking = new Booking(tableNo, (booked) ? BookingDateTime : new DateTime(1, 1, 1, 0, 0, 0));
                        Tables[row, col] = newBooking;

                        tableNo++;
                    }
                    Console.WriteLine();
                }

                //vraag gebruiker om tafel reservering
                int ttr = 0; //tafel te reserveren
                string name = "";
                string personen = "";
                while (true)
                {
                    Console.WriteLine("\nKies welke tafel u wilt hebben: ");
                if (!Int32.TryParse(Console.ReadLine(), out ttr)) //als gebruiker een foute waarde geeft
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ongeldige tafel nummer.");
                    Console.ResetColor();
                }
                else
                {
                    //check of het een geldige tafel nummer is
                    if (!(ttr >= 1 && ttr <= 16))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOngeldige tafel nummer.");
                        Console.ResetColor();
                    }
                    else
                    {
                        //check of de tafel al bezet is
                        bool reserved = false;
                        for (int row = 0; row <= 3; row++)
                        {
                            for (int col = 0; col <= 3; col++)
                            {
                                Booking cb = Tables[row, col];
                                if (cb.TableNo == ttr && cb.BookingDateTime.Year != 1)
                                {
                                    reserved = true;
                                    break;
                                }
                            }
                            if (reserved)
                                break;
                        }

                        if (reserved)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nDeze tafel is bezet.");
                            Console.ResetColor();
                        }
                        else
                        {
                        name:
                            Console.WriteLine("Onder welke naam wilt u reserveren? ");
                            name = Console.ReadLine()!;
                            if (!name.All(char.IsLetter))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Een naam mag alleen letters bevatten! Voer uw naam opnieuw in.");
                                Console.ResetColor();
                                goto name;
                            }
                            if (name.Length < 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Te korte naam! Voer uw naam opnieuw in.");
                                Console.ResetColor();
                                goto name;
                            }

                        howmanypeople:
                            Console.WriteLine("Voor hoeveel personen wilt u reserveren? ");
                            personen = Console.ReadLine()!;
                            if (personen == "1" || personen == "2" || personen == "3" || personen == "4" || personen == "5" || personen == "6" || personen == "7" || personen == "8")
                            {
                                int x = Int32.Parse(personen);
                                if (x <= 0 || x > 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nVul een waarde tussen 1 en 8 in,\nals u wilt reserveren voor meer dan 8 personen, neem dan contact met ons op.");
                                    Console.ResetColor();
                                    goto howmanypeople;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nVul een waarde tussen 1 en 8 in,\nals u wilt reserveren voor meer dan 8 personen, neem dan contact met ons op.");
                                Console.ResetColor();
                                goto howmanypeople;
                            }


                        }
                    }
                }
                }

                //sla op in json
                Booking newBookingToSave = new Booking(ttr, BookingDateTime);
                newBookingToSave.BookingName = name;
                newBookingToSave.aantalpersonen = personen;
                bookings.Add(newBookingToSave);
                File.WriteAllText(file, JsonConvert.SerializeObject(bookings));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccesvol gereserveerd.");
                Console.ResetColor();

               // Console.ReadKey();
                Betalen();
               
        }
        


        #endregion 4
        //betalen
        #region 5
        // Betalen

        public static void Betalen()
        {
            // Voorpagina met variabeles
            var page = 0;
            var Vooraf = "1";
            var Achteraf = "2";
            //var gaTerug = "*";
            while (page == 0)
            {
                // Wanneer willen ze betalen
                Console.WriteLine("\nBetaalt u liever vooraf of achteraf?\n[1] Vooraf\n[2] Achteraf\n");
                var wanneer = Console.ReadLine();
                if (wanneer == Achteraf)
                {
                    // wanneer achteraf wordt gekozen
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nU kunt achteraf met VISA, Mastercard, Ideal of contant betalen.");
                    Console.ResetColor();
                    break;
                }
                if (wanneer == Vooraf)
                {
                    // Met welke pas willen ze betalen
                    page = 1;
                    Console.WriteLine("\nToets uw betaalmethode.\n[*] Terug\n[1] IDEAL\n[2] VISA\n[3] Mastercard\n");
                    var methode = Console.ReadLine();
                    if (methode == "1")
                    {
                        Console.WriteLine("\nToets uw bank met de onderstaande keuzes.\n[*] Terug\n[1] ABN AMRO\n[2] ING\n[3] RABO\n");
                        var bankInput = Console.ReadLine();
                        // bankopties
                        if (bankInput == "1" || bankInput == "2" || bankInput == "3")
                        {
                            Bevestig:  Console.WriteLine("\nBevestig uw betaling door op 1 te drukken.\n[1] Ja\n[*] Terug\n");
                            var bevestig = Console.ReadLine();

                            if (bevestig == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nBedankt voor uw betaling.\n Tot ziens!");
                                Console.ResetColor();

                            }

                            else if (bevestig == "*")
                            {
                                page = 0;
                            }
                            else
                            {
                                goto Bevestig;
                            }
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nVerkeerde input, probeer nogmaals.");
                            Console.ResetColor();
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
                            Console.WriteLine("\nVoer uw kaartnummer in.");
                            while (true)
                            {
                                while (!double.TryParse(Console.ReadLine(), out cardNumber))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\nVoer alleen nummers in. Probeer nogmaals.\n");
                                    Console.ResetColor();
                                }
                                if ((cardNumber.ToString()).Length != 16)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\nDe ingevoerde kaartnummer is geen 16 getallen. Probeer nogmaals.\n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("\nTot wanneer is het geldig?");
                            Console.WriteLine("DATUM MM-YYYY");
                            while (true)
                            {
                                while (!DateTime.TryParseExact(Console.ReadLine(), "M-yyyy", null, System.Globalization.DateTimeStyles.None, out datum))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\nAlleen een datum in het formaat MM-YYYY is toegestaan. Probeer nogmaals.\n");
                                    Console.ResetColor();

                                }
                                if (((datum.Year < DateTime.Now.Year) || (datum.Year == DateTime.Now.Year) && (datum.Month < DateTime.Now.Month)) || (datum.Year > DateTime.Now.Year + 5) || (datum.Year >= DateTime.Now.Year + 5) && (datum.Month > DateTime.Now.Month))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\nVoer alsjeblieft een geldig jaar en maand in. Probeer nogmaals.\n");
                                    Console.ResetColor();
                                }

                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("\nVoer uw CVC in.");
                            while (true)
                            {
                                while (!double.TryParse(Console.ReadLine(), out pin))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("Voer alleen nummers in. Probeer nogmaals.\n");
                                    Console.ResetColor();
                                }
                                if ((pin.ToString()).Length != 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("De ingevoerde CVC moet uit drie getallen bestaan. Probeer nogmaals.\n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            page = 1;
                            Console.WriteLine("\nBevestig uw betaling door op 1 te drukken.\n[1] Ja\n[2] Nee");
                            var bevestig = Console.ReadLine();
                            if (bevestig == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nBedankt voor uw betaling.\n Tot ziens!");
                                Console.ResetColor();
                            }
                            else if (bevestig == "2")
                            {
                                page = 0;
                            }
                        }
                    }
                    else if (methode == "*")
                    {
                        page = 0;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nVerkeerde input, probeer nogmaals.");
                        Console.ResetColor();
                        page = 0;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nVerkeerde input, probeer nogmaals.");
                    Console.ResetColor();
                    page = 0;
                }
            }
        
        }
        #endregion 5
        //menu
        #region 6

        static void Menu()
        {
            static void Laat_gerechten_zien()
            {
                // Maakt een list van Alle Gerechten
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
                                    Name = "3. Thaise Tom kha kai soep",
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
                Console.Clear();
                // serialize de list en maakt er een json file van
                var GerechtenJson = JsonConvert.SerializeObject(alle_gerechten);
                File.WriteAllText(@"Alle_gerechten.json", GerechtenJson);

                // Laat alle gerechten zien

                foreach (Alle_gerechten g in alle_gerechten)
                {
                    string display_A = $"| {g.Name}{TekenString(50 - g.Name.Length, " ")}${g.Price}";
                    Console.WriteLine(display_A);

                }
            }

            static string TekenString(int Length, string character)
            {

                string Zijkant = "";
                for (int i = 0; i < Length; i++) { Zijkant += character; }
                return Zijkant;
            }
                // beginscherm bij het menu , gebruiker kan uit 2 keuzes nemen
        Begin: Console.WriteLine("Menukaart \n");
            Console.WriteLine(" Kies [1] voor de Menu");
            Console.WriteLine(" Kies [2] voor een keuze maken \n\n ");

        dot: Console.WriteLine("\n\n\n");
            Console.WriteLine("Type een nummer in : ");


            string a = Console.ReadLine()!;
            // kijkt of de gebruiker een intreger invult
            if (!int.TryParse(a, out int value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Probeer het opnieuw , vul een nummer in");
                Console.ResetColor();
                goto dot;
            }
            else
            {
                
                int Choose_nummer = Convert.ToInt32(a);

                if (Choose_nummer == 1)
                {
                Vier:
                    Laat_gerechten_zien();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\n [*] Terug");
                    Console.ResetColor();

                    string Back = Console.ReadLine()!;
                    if (Back == "*")
                    {
                        Console.Clear();
                        goto Begin;
                    }
                    else
                    {
                        goto Vier;
                    }
                }
                else if (Choose_nummer == 2)
                {
                    Console.Clear();
                    // Hij opent de text file leest alle file in een string en sluit de file

                    var json1 = "./Gerechten_kiezen.json";
                    string Gerechten_lezen = File.ReadAllText(json1);
                    // toegang tot je file deserialize.
                    var d = JsonConvert.DeserializeObject<Gerechten_kiezen>(Gerechten_lezen);

                    double Totaalprijs = 0;
                    string Overzicht_Gerechten = "";
                    Laat_gerechten_zien();
                Terug_naar_Nummer_1:
                    Console.WriteLine("\nVul een gerecht nummer in :");
                Terug_naar_Nummer:
                    string Kiesnummer_1 = Console.ReadLine()!;

                    Totaal_Bedrag totaalbedrag = new Totaal_Bedrag()
                    {
                        Gekozen_Gerechten = Overzicht_Gerechten,
                        Gekozen_Prijzen = Totaalprijs
                    };
                    string strResulJson = JsonConvert.SerializeObject(totaalbedrag);

                    File.WriteAllText("./Totaalbedrag.json", strResulJson);

                    if (Kiesnummer_1 == "ja" || Kiesnummer_1 == "Ja")
                    {
                        Reserveren();
                    }
                    else if (!int.TryParse(Kiesnummer_1, out int nummer))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Probeer het opnieuw , vul een nummer in");
                        Console.ResetColor();
                        goto Terug_naar_Nummer_1;
                    }
                    else
                    {
                        int Naarint = Convert.ToInt32(Kiesnummer_1);
                        string ein_0 = "Naam : " + d.Name[0] + "  Prijs : " + d.Price[0];
                        string ein_1 = "Naam : " + d.Name[1] + "  Prijs : " + d.Price[1];
                        string ein_2 = "Naam : " + d.Name[2] + "  Prijs : " + d.Price[2];
                        string ein_3 = "Naam : " + d.Name[3] + "  Prijs : " + d.Price[3];
                        string ein_4 = "Naam : " + d.Name[4] + "  Prijs : " + d.Price[4];
                        string ein_5 = "Naam : " + d.Name[5] + "  Prijs : " + d.Price[5];
                        string ein_6 = "Naam : " + d.Name[6] + "  Prijs : " + d.Price[6];
                        string ein_7 = "Naam : " + d.Name[7] + "  Prijs : " + d.Price[7];
                        string ein_8 = "Naam : " + d.Name[8] + "  Prijs : " + d.Price[8];
                        string ein_9 = "Naam : " + d.Name[9] + "  Prijs : " + d.Price[9];
                        string ein_10 = "Naam : " + d.Name[10] + " Prijs : " + d.Price[10];
                        string ein_11 = "Naam : " + d.Name[11] + " Prijs : " + d.Price[11];
                        string ein_12 = "Naam : " + d.Name[12] + " Prijs : " + d.Price[12];
                        string ein_13 = "Naam : " + d.Name[13] + " Prijs : " + d.Price[13];
                        string ein_14 = "Naam : " + d.Name[14] + " Prijs : " + d.Price[14];
                        string ein_15 = "Naam : " + d.Name[15] + " Prijs : " + d.Price[15];
                        string ein_16 = "Naam : " + d.Name[16] + " Prijs : " + d.Price[16];
                        string ein_17 = "Naam : " + d.Name[17] + " Prijs : " + d.Price[17];
                        string ein_18 = "Naam : " + d.Name[18] + " Prijs : " + d.Price[18];
                        string ein_19 = "Naam : " + d.Name[19] + " Prijs : " + d.Price[19];
                        string ein_20 = "Naam : " + d.Name[20] + " Prijs : " + d.Price[20];
                        string ein_21 = "Naam : " + d.Name[21] + " Prijs : " + d.Price[21];
                        string ein_22 = "Naam : " + d.Name[22] + " Prijs : " + d.Price[22];
                        string ein_23 = "Naam : " + d.Name[23] + " Prijs : " + d.Price[23];
                        string ein_24 = "Naam : " + d.Name[24] + " Prijs : " + d.Price[24];
                        string ein_25 = "Naam : " + d.Name[25] + " Prijs : " + d.Price[25];
                        string ein_26 = "Naam : " + d.Name[26] + " Prijs : " + d.Price[26];
                        string ein_27 = "Naam : " + d.Name[27] + " Prijs : " + d.Price[27];

                        if (Naarint == 1)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_0);
                            Totaalprijs = Totaalprijs + d.Price[0];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[0] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;


                        }
                        else if (Naarint == 2)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_1);
                            Totaalprijs = Totaalprijs + d.Price[1];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[1] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);

                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;

                        }
                        else if (Naarint == 3)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_2);
                            Totaalprijs = Totaalprijs + d.Price[2];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[2] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;

                        }
                        else if (Naarint == 4)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_3);
                            Totaalprijs = Totaalprijs + d.Price[3];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[3] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;

                        }
                        else if (Naarint == 5)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_4);
                            Totaalprijs = Totaalprijs + d.Price[4];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[4] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;

                        }
                        else if (Naarint == 6)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_5);
                            Totaalprijs = Totaalprijs + d.Price[5];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[5] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 7)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_6);
                            Totaalprijs = Totaalprijs + d.Price[6];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[6] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 8)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_7);
                            Totaalprijs = Totaalprijs + d.Price[7];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[7] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs); ;
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 9)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_8);
                            Totaalprijs = Totaalprijs + d.Price[8];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[8] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 10)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_9);
                            Totaalprijs = Totaalprijs + d.Price[9];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[9] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 11)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_10);
                            Totaalprijs = Totaalprijs + d.Price[10];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[10] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 12)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_11);
                            Totaalprijs = Totaalprijs + d.Price[11];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[11] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 13)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_12);
                            Totaalprijs = Totaalprijs + d.Price[12];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[12] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 14)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_13);
                            Totaalprijs = Totaalprijs + d.Price[13];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[13] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 15)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_14);
                            Totaalprijs = Totaalprijs + d.Price[14];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[14] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 16)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_15);
                            Totaalprijs = Totaalprijs + d.Price[15];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[15] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs); ;
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 17)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_16);
                            Totaalprijs = Totaalprijs + d.Price[16];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[16] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 18)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_17);
                            Totaalprijs = Totaalprijs + d.Price[17];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[17] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 19)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_18);
                            Totaalprijs = Totaalprijs + d.Price[18];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[18] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 20)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_19);
                            Totaalprijs = Totaalprijs + d.Price[19];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[19] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 21)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_20);
                            Totaalprijs = Totaalprijs + d.Price[20];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[20] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 22)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_21);
                            Totaalprijs = Totaalprijs + d.Price[21];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[21] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\nntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 23)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_22);
                            Totaalprijs = Totaalprijs + d.Price[22];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[22] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 24)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_23);
                            Totaalprijs = Totaalprijs + d.Price[23];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[23] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 25)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_24);
                            Totaalprijs = Totaalprijs + d.Price[24];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[24] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 26)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_25);
                            Totaalprijs = Totaalprijs + d.Price[25];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[25] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 27)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_26);
                            Totaalprijs = Totaalprijs + d.Price[26];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[26] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else if (Naarint == 28)
                        {
                            Laat_gerechten_zien();
                            Console.WriteLine("\n");
                            Console.WriteLine(ein_27);
                            Totaalprijs = Totaalprijs + d.Price[27];
                            Overzicht_Gerechten = Overzicht_Gerechten + d.Name[27] + "\n";
                            Console.WriteLine("\n\nOverzicht = \n" + Overzicht_Gerechten);
                            Console.WriteLine("\n\ntotaalprijs = " + Totaalprijs);
                            Console.WriteLine("Kies de gerecht nummer of type 'ja' om verder te gaan met reserveren");
                            goto Terug_naar_Nummer;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Kies tussen de nummers 1 en 28 !!!!");
                            Console.ResetColor();
                            goto Terug_naar_Nummer_1;
                        }

                    }

                }
              
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Nummer mislukt,  Kies tussen de nummers [1] , [2]");
                    Console.ResetColor();
                    goto dot;
                }


            }
        }

        
        #endregion 6
        #endregion 0
    }
}


