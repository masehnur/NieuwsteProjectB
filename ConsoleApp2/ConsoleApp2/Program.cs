﻿using System;

namespace Project_B_week_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menu = "\nHoofdmenu optie hebben:\n\n1- Reserveren. \n2- Menu kaart zien.\n3- Algemene informatie tonen.\nKlik op een ster om terug naar het hoofdmenu.";

        Startpoint: Console.WriteLine("Welkom bij ons restaurant!\n");
            Console.WriteLine("1- Rerserveren. \n2- Reserveren en vooraf bestellen. \n3- algemene informatie.\n\n-Voer een van de bovenstaande nummers in: \n ");


            string Start;
            Start = Console.ReadLine();

            if (Start == "1")
            {

                Console.Clear();
                Console.WriteLine("Kies uw gewenste zitplek: \n");
                string gostart = Console.ReadLine();
                if (gostart == "*")
                {
                    Console.Clear();
                    goto Startpoint;
                }
                else { Console.WriteLine("Klik op een ster om terug naar het hoofdmenu."); }
            }

            else if (Start == "2")
            {
                Console.Clear();
                Console.WriteLine("Wat wilt u eten?\n");
                string gostart = Console.ReadLine();
                if (gostart == "*")
                {
                    Console.Clear();
                    goto Startpoint;
                }
                else { Console.WriteLine("Klik op een ster om terug naar het hoofdmenu."); }
            }
            
            else if (Start == "3")
            {
                Console.Clear(); ;
                Console.WriteLine("Openingstijden: maandag t/m vrijdag 10:00-22:00. \nweekend 12:00-24:00\n\nContact: telefoonnummer; 070 34 24818.\n\nAdres: Wijnhaven 107, 8518KA, Rotterdam \n\nKlik op een ster om terug naar het hoofdmenu\n");
                string gostart = Console.ReadLine();
                if (gostart == "*")
                {
                    Console.Clear();
                    goto Startpoint;
                }
                else { Console.WriteLine("Klik op een ster om terug naar het hoofdmenu."); }

            }

        }

    }
}