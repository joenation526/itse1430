/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */


using System;

namespace PizzaCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaMenu();
        }

        private static void PizzaMenu ()
        {

            ReadInput();

        }

        private static void ReadInput ()
        {
            do
            {
                // Create the menu
                Console.WriteLine("Choose your pizza option");
                Console.WriteLine("1. New order\n" + "2. Display order\n" + "3. Modify order\n" + "0. Quit\n");

                // User should only be able to select 1-3 or 0 
                string selection = Console.ReadLine();
                do
                {

                    // Error check for user input
                    if (String.IsNullOrEmpty(selection))
                    {
                        Console.WriteLine("Please enter a value.");
                    } else if (selection != "1" && selection != "2" && selection != "3" && selection != "0")
                    {
                        Console.WriteLine("Please enter in key values 1-3 or 0.");
                    }

                    // the quit option prompt
                    if (selection == "0")
                    {
                        Console.WriteLine("Are you sure? (Y/N)");

                        selection = Console.ReadLine();

                        if (selection == "N" || selection == "n")
                        {
                            break;
                        }
                    }

                    // Current price needs to be shown on the menu

                } while (true);

            } while (true);
        }
    }
}
