using System;

namespace ProjectB_Leeftijd
{
    internal class Program

    {    // de gebruiker is minstens 16  method
        static void checkAge()
        {
            int input;

            Console.Write("\nVoer uw leeftijd in: ");

            // Zorg ervoor dat de waarde geldig is, en niet letters
            while (!int.TryParse(Console.ReadLine(), out input) || input > 102 || input < 16)
            {

                if (input == 0 || input > 102)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ongeldige waarde, voer uw echte leeftijd in: ");
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                else if (input > 3)
                {
                    Console.WriteLine("U kunt geen account aanmaken.");
                    break;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ongeldige leeftijd Data!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write("\nVoer uw echte leeftijd in: ");
            }

            if (input > 15 && input < 102)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("U kunt een account aanmaken.\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        // Hoofd Method 
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom in ons resturant!");
            checkAge();
        }
    }
}

