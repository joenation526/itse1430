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
        // total amount of acummulated for the pizza 
        static double totalPrice;
        static bool done = false;

        static void Main ( string[] args )
        {

            do
            {
                switch (PizzaMenu())
                {
                    case Command.New: NewOrder(); break;
                    case Command.Display: break;
                    case Command.Modify: break;
                    case Command.Quit: Exit(); break;
                };
            } while (!done);
        }

        private static Command PizzaMenu ()
        {
            // when user doesn't input anything an error is thown. Need to error check for this
            do
            {
                Console.WriteLine("Choose your pizza option");
                Console.WriteLine("1. New order\n" + "2. Display order\n" + "3. Modify order\n" + "0. Quit\n");

                Console.WriteLine("Current Price " + totalPrice.ToString("C"));

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": return Command.New;
                    case "2": return Command.Display;
                    case "3": return Command.Modify;
                    case "0": return Command.Quit;    // this needs to be checked by using the Y/N options 

                    default: Console.WriteLine("ERROR: Please enter the number keys 1-3 or 0.\n"); break;
                };
            } while (true);
        }

        private static void Exit ()
        {
            Console.WriteLine("Are you sure? (Y/N)?");

            do
            {
                string value = Console.ReadLine();
                if (!String.IsNullOrEmpty(value))
                {
                    if (String.Compare(value, "Y", true) == 0)
                    {
                        done = true;
                        return;
                    } 
                    else if (String.Compare(value, "N", true) == 0)
                    {
                        done = false;
                        return;
                    }
                };
                Console.WriteLine("Enter Y or N");
            } while (true);

        }

        enum Command
        { 
            New = 1,
            Display = 2,
            Modify = 3, 
            Quit = 0,
        }

        static void NewOrder ()
        {
            Console.WriteLine("New order ");
            Console.WriteLine("-----------");

            do
            {
                PizzaSize();

                Meats();

                Vegetables();

                Sauce();

                Delivery();

                break;

            } while (true);
        }

        private static void Delivery ()
        {
            throw new NotImplementedException();
        }

        private static void Sauce ()
        {
            Console.WriteLine("Sauce: (One is Required)");
            Console.WriteLine("1. Traditional ($0)");
            Console.WriteLine("2. Garlic ($1)");
            Console.WriteLine("3. Oregano ($1)");
            Console.WriteLine("0. NEXT->");

            var selection = Console.ReadLine();
            const double pizzaSauce = 1;


            switch (selection)
            {
                case "1": Console.WriteLine("Traditional Sauce Added."); break;
                case "2": Console.WriteLine("Garlic Sauce Added."); totalPrice += pizzaSauce; break;
                case "3": Console.WriteLine("Oregano Added."); totalPrice += pizzaSauce; break;

                default: Console.WriteLine("Use the 1-4 num keys or press 0 to proceed."); break;
            }
        }

        private static void Vegetables ()
        {
            Console.WriteLine("Vegetables: ($0.75 per selection)");
            Console.WriteLine("1. Black Olives");
            Console.WriteLine("2. Mushrooms");
            Console.WriteLine("3. Onions");
            Console.WriteLine("4. Peppers");
            Console.WriteLine("0. NEXT->");

            do
            {
                var meatSelect = Console.ReadLine();
                const double veggies = 0.50;

                switch (meatSelect)
                {
                    case "1": Console.WriteLine("Black Olives Added."); totalPrice += veggies; break;
                    case "2": Console.WriteLine("Mushrooms Added."); totalPrice += veggies; break;
                    case "3": Console.WriteLine("Onions Added."); totalPrice += veggies; break;
                    case "4": Console.WriteLine("Peppers Added."); totalPrice += veggies; break;
                    case "0": return;

                    default: Console.WriteLine("Use the 1-4 num keys or press 0 to proceed."); break;
                }
            } while (true);
        }

        private static void Meats ()
        {
            Console.WriteLine("Meats: ($0.75 per selection)");
            Console.WriteLine("1. Bacon");
            Console.WriteLine("2. Ham");
            Console.WriteLine("3. Pepperoni");
            Console.WriteLine("4. Sausage");
            Console.WriteLine("0. NEXT->");

            do 
            {
                var meatSelect = Console.ReadLine();
                const double meats = 0.75;

                switch (meatSelect)
                {
                    case "1": Console.WriteLine("Bacon Added."); totalPrice += meats; break;
                    case "2": Console.WriteLine("Ham Added."); totalPrice += meats; break;
                    case "3": Console.WriteLine("Pepperoni Added."); totalPrice += meats; break;
                    case "4": Console.WriteLine("Sausage Added."); totalPrice += meats; break;
                    case "0": return;
                   
                    default: Console.WriteLine("Use the 1-4 num keys or press 0 to proceed."); break;
                }
            } while (true);
        }

        private static void PizzaSize ()
        {
            Console.WriteLine("\nChoose your Pizza size: ");
            Console.WriteLine("1. Small ($5)");
            Console.WriteLine("2. Medium ($6.25)");
            Console.WriteLine("3. Large ($7)");


            do
            {
                string pizzaSize = Console.ReadLine();
                const double small = 5.00;
                const double medium = 5.00;
                const double large = 5.00;

                switch (pizzaSize)
                {
                    case "1": totalPrice += small; return;
                    case "2": totalPrice += medium; return;
                    case "3": totalPrice += large; return;

                    default: Console.WriteLine("Please choose a pizza size using 1-3 num keys"); break;
                }
            } while (true);
            
        }
    }
}
