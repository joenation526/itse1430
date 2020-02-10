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
        private static bool done = false;

        static void Main ( string[] args )
        {

            do
            {
                switch (PizzaMenu())
                {
                    case Command.New: NewOrder(); break;
                    case Command.Display: DisplayOrder(); break;
                    case Command.Modify: ModifyOrder(); break;
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
                Console.WriteLine("Cart Price " + totalPrice.ToString("C"));

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
                    } else if (String.Compare(value, "N", true) == 0)
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

        static double totalPrice;

        private static void NewOrder ()
        {

            if (totalPrice != 0)
            {
                if (OverWrite() == false)
                {
                    return;
                }
            }

            do
            {
                PizzaSize();

                Meats();

                Vegetables();

                Sauce();

                Cheese();

                Delivery();

                Console.WriteLine();

                DisplayOrder();

                Console.WriteLine();

                break;

            } while (true);
        }

        private static bool OverWrite ()
        {
            do
            {
                Console.WriteLine("Order already exist. Do you want to overwrite existing order? (Y/N)");

                string value = Console.ReadLine();

                if (!String.IsNullOrEmpty(value))
                {
                    if (String.Compare(value, "Y", true) == 0)
                    {
                        pizzaSizeDisplay = "";
                        meatDisplay = "";
                        vegatableDisplay = "";
                        sauceDisplay = "";
                        deliveryDisplay = "";
                        totalPrice = 0;
                        return true;
                    } else if (String.Compare(value, "N", true) == 0)
                    {
                        return false;
                    }
                };
                Console.WriteLine("Enter Y or N");
            } while (true);
        }

        static double pizzaSize;

        private static void PizzaSize ()
        {
            do
            {
                Console.WriteLine("\nChoose your Pizza size: ");
                Console.WriteLine("1. Small ($5)");
                Console.WriteLine("2. Medium ($6.25)");
                Console.WriteLine("3. Large ($7)");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": pizzaSize = 5; totalPrice += pizzaSize; pizzaSizeDisplay = "Small Pizza\t\t" + pizzaSize.ToString("C"); return;
                    case "2": pizzaSize = 6.25; totalPrice += pizzaSize; pizzaSizeDisplay = "Medium Pizza\t\t" + pizzaSize.ToString("C"); return;
                    case "3": pizzaSize = 7; totalPrice += pizzaSize; pizzaSizeDisplay = "Large Pizza\t\t" + pizzaSize.ToString("C"); return;

                    default: Console.WriteLine("Please choose a pizza size using 1-3 num keys"); break;
                }
            }
            while (true);
        }

        
        static double meats = 0.75;

        private static void Meats ()
        {
            do
            {
                Console.WriteLine("Meats: ($0.75 per selection)");
                Console.WriteLine("1. Bacon");
                Console.WriteLine("2. Ham");
                Console.WriteLine("3. Pepperoni");
                Console.WriteLine("4. Sausage");
                Console.WriteLine("0. NEXT->");

                Console.WriteLine(meatDisplay);

                var selection = Console.ReadLine();

                // Need to unselect somehow......
                switch (selection)
                {
                    case "1": Console.WriteLine("Bacon Added."); totalPrice += meats; meatDisplay += "\tBacon\t\t" + meats.ToString("C") + "\n"; break;
                    case "2": Console.WriteLine("Ham Added."); totalPrice += meats; meatDisplay += "\tHam\t\t" + meats.ToString("C") + "\n"; break;
                    case "3": Console.WriteLine("Pepperoni Added."); totalPrice += meats; meatDisplay += "\tPepperoni\t" + meats.ToString("C") + "\n"; break;
                    case "4": Console.WriteLine("Sausage Added."); totalPrice += meats; meatDisplay += "\tSausage\t\t" + meats.ToString("C") + "\n"; break;
                    case "0": return;

                    default: Console.WriteLine("Please use the number keys or press 0 to proceed."); break;
                }
            }
            while (true);
        }

        static double veggies = 0.50;

        private static void Vegetables ()
        {
            Console.WriteLine("Vegetables: ($0.50 per selection)");
            Console.WriteLine("1. Black Olives");
            Console.WriteLine("2. Mushrooms");
            Console.WriteLine("3. Onions");
            Console.WriteLine("4. Peppers");
            Console.WriteLine("0. NEXT->");

            do
            {
                Console.WriteLine(vegatableDisplay);

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": Console.WriteLine("Black Olives Added."); totalPrice += veggies; vegatableDisplay += "\tBlack Olives\t" + veggies.ToString("C") + "\n"; break;
                    case "2": Console.WriteLine("Mushrooms Added."); totalPrice += veggies; vegatableDisplay += "\tMushrooms\t" + veggies.ToString("C") + "\n"; break;
                    case "3": Console.WriteLine("Onions Added."); totalPrice += veggies; vegatableDisplay += "\tOnions\t\t" + veggies.ToString("C") + "\n"; break;
                    case "4": Console.WriteLine("Peppers Added."); totalPrice += veggies; vegatableDisplay += "\tPeppers\t\t" + veggies.ToString("C") + "\n"; break;
                    case "0": return;

                    default: Console.WriteLine("Please use the number keys or press 0 to proceed."); break;
                }
            } while (true);
        }

        static double pizzaSauce = 1;

        private static void Sauce ()
        {
            Console.WriteLine("Sauce: (One is Required)");
            Console.WriteLine("1. Traditional ($0)");
            Console.WriteLine("2. Garlic ($1)");
            Console.WriteLine("3. Oregano ($1)");

            do
            {
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": Console.WriteLine("Traditional Sauce Added."); sauceDisplay = "\tTraditional\t\t"; return;
                    case "2": Console.WriteLine("Garlic Sauce Added."); totalPrice += pizzaSauce; sauceDisplay = "\tGarlic\t\t" + pizzaSauce.ToString("C") + "\n"; return;
                    case "3": Console.WriteLine("Oregano Added."); totalPrice += pizzaSauce; sauceDisplay = "\tOregano\t\t" + pizzaSauce.ToString("C") + "\n"; return;

                    default: Console.WriteLine("Please pick a sauce."); break;
                }
            }
            while (true);

        }

        static double extraCheese = 1.50;

        private static void Cheese ()
        {
            Console.WriteLine("Cheese");
            Console.WriteLine("1. Regular ($0)");
            Console.WriteLine("2. Extra ($1.50)");

            do
            {
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": Console.WriteLine("Regular cheese added"); cheeseDisplay = "\tRegular cheese\t\t"; return;
                    case "2": Console.WriteLine("Extra cheese added"); totalPrice += extraCheese; cheeseDisplay = "\tExtra cheese\t\t" + extraCheese.ToString("C"); return;

                    default: Console.WriteLine("Please choose one of the options."); break;
                }

            } while (true);
        }

        static double takeOut = 0;
        static double deliver = 2.50;

        private static void Delivery ()
        {
            Console.WriteLine("Take out or Delivery?");
            Console.WriteLine("1. Take out ($0)");
            Console.WriteLine("2. Delivery ($2.50)");

            do
            {
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": Console.WriteLine("Take out"); deliveryDisplay = "Take out\t\t" + takeOut.ToString("C"); return;
                    case "2": Console.WriteLine("Delivery Added."); totalPrice += deliver; deliveryDisplay = "Delivery\t\t" + deliver.ToString("C"); return;

                    default: Console.WriteLine("Please choose one of the options."); break;
                }

            } while (true);

        }

        static string pizzaSizeDisplay;
        static string meatDisplay;
        static string vegatableDisplay;
        static string sauceDisplay;
        static string cheeseDisplay;
        static string deliveryDisplay;
        private static void DisplayOrder ()
        {
            if (String.IsNullOrEmpty(pizzaSizeDisplay))
            {
                Console.WriteLine("No Order has been created");
                return;
            }

            Console.WriteLine("\n" + pizzaSizeDisplay);

            Console.WriteLine(deliveryDisplay);

            Console.Write("Meats:\n" + meatDisplay);

            Console.Write("Vegatables:\n" + vegatableDisplay);

            Console.WriteLine("Cheese:\n" + cheeseDisplay);

            Console.WriteLine("Sauce:\n" + sauceDisplay);

            var header = "".PadRight(30, '-'); //------

            Console.WriteLine(header);

            Console.WriteLine("Total Price " + totalPrice.ToString("C"));
        }

        private static void ModifyOrder ()
        {
            if (pizzaSize == 0)
            {
                Console.WriteLine("Order does not exist");
                return;
            }

            // If the user selects yes they can modify their order
            if (Modify() == true)
            {
                PizzaSize();

                Meats();

                Vegetables();

                Sauce();

                Cheese();

                Delivery();

                DisplayOrder();
            }
        }

        private static bool Modify ()
        {
            do
            {
                Console.WriteLine("Are you sure you want to modify your order? (Y/N)");

                string value = Console.ReadLine();

                if (!String.IsNullOrEmpty(value))
                {
                    if (String.Compare(value, "Y", true) == 0)
                    {
                        return true;
                    } else if (String.Compare(value, "N", true) == 0)
                    {
                        return false;
                    }
                };

                Console.WriteLine("Enter Y or N");

            } while (true);
        }
    }
}
