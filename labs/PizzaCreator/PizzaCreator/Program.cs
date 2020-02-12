/*
 * ITSE 1430
 * Spring 2020
 * Jonathan Saysanam
 */

using System;
using System.Text;

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

                DisplayOrder();

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
                        pizzaSizeDisplay = ""; meatDisplay = ""; vegatableDisplay = ""; sauceDisplay = ""; deliveryDisplay = "";

                        baconDisplay = ""; hamDisplay = ""; pepperoniDisplay = ""; sausageDisplay = "";

                        oliveDisplay = ""; mushroomDisplay = ""; onionDisplay = ""; pepperDisplay = "";

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
            Console.WriteLine("\nChoose your Pizza size: ");
            Console.Write("1. Small ($5) "); if (pizzaSizeDisplay == "Small Pizza\t\t" + pizzaSize.ToString("C")) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
            Console.Write("2. Medium ($6.25) "); if (pizzaSizeDisplay == "Medium Pizza\t\t" + pizzaSize.ToString("C")) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
            Console.Write("3. Large ($7) "); if (pizzaSizeDisplay == "Large Pizza\t\t" + pizzaSize.ToString("C")) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };

            do
            {
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
                Console.Write("1. Bacon "); if (!String.IsNullOrEmpty(baconDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.Write("2. Ham "); if (!String.IsNullOrEmpty(hamDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.Write("3. Pepperoni "); if (!String.IsNullOrEmpty(pepperoniDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.Write("4. Sausage "); if (!String.IsNullOrEmpty(sausageDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.WriteLine("0. NEXT->");
                Console.WriteLine();

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": if (!String.IsNullOrEmpty(baconDisplay)) { MeatDeselect(selection); break; }; totalPrice += meats; baconDisplay = "\tBacon\t\t" + meats.ToString("C") + "\n"; break;
                    case "2": if (!String.IsNullOrEmpty(hamDisplay)) { MeatDeselect(selection); break; }; totalPrice += meats; hamDisplay = "\tHam\t\t" + meats.ToString("C") + "\n"; break;
                    case "3": if (!String.IsNullOrEmpty(pepperoniDisplay)) { MeatDeselect(selection); break; }; totalPrice += meats; pepperoniDisplay = "\tPepperoni\t" + meats.ToString("C") + "\n"; break;
                    case "4": if (!String.IsNullOrEmpty(sausageDisplay)) { MeatDeselect(selection); break; }; totalPrice += meats; sausageDisplay = "\tSausage\t\t" + meats.ToString("C") + "\n"; break;
                    case "0": return;

                    default: Console.WriteLine("Select meats using number keys or press 0 to proceed."); break;
                }
            }
            while (true);
        }

        static string baconDisplay;
        static string hamDisplay;
        static string pepperoniDisplay;
        static string sausageDisplay;

        private static void MeatDeselect ( string deselect )
        {
                switch (deselect)
                {
                    case "1": totalPrice -= meats; baconDisplay = null; return;
                    case "2": totalPrice -= meats; hamDisplay = null; return;
                    case "3": totalPrice -= meats; pepperoniDisplay = null; return;
                    case "4": totalPrice -= meats; sausageDisplay = null; return;
                    case "0": return;

                    default: Console.WriteLine("Select meats or press 0 to proceed."); break;
                }
        }


        static double veggies = 0.50;
        static string oliveDisplay;
        static string mushroomDisplay;
        static string onionDisplay;
        static string pepperDisplay;

        private static void Vegetables ()
        {
            do
            {
                Console.WriteLine("Vegetables: ($0.50 per selection)");
                Console.Write("1. Black Olives "); if (!String.IsNullOrEmpty(oliveDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.Write("2. Mushrooms "); if (!String.IsNullOrEmpty(mushroomDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.Write("3. Onions "); if (!String.IsNullOrEmpty(onionDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.Write("4. Peppers "); if (!String.IsNullOrEmpty(pepperDisplay)) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
                Console.WriteLine("0. NEXT->");
                Console.WriteLine();

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": if (!String.IsNullOrEmpty(oliveDisplay)) { VeggieDeselect(selection); break; }; totalPrice += veggies; oliveDisplay = "\tBlack Olives\t" + veggies.ToString("C") + "\n"; break;
                    case "2": if (!String.IsNullOrEmpty(mushroomDisplay)) { VeggieDeselect(selection); break; }; totalPrice += veggies; mushroomDisplay = "\tMushrooms\t" + veggies.ToString("C") + "\n"; break;
                    case "3": if (!String.IsNullOrEmpty(onionDisplay)) { VeggieDeselect(selection); break; }; totalPrice += veggies; onionDisplay = "\tOnions\t\t" + veggies.ToString("C") + "\n"; break;
                    case "4": if (!String.IsNullOrEmpty(pepperDisplay)) { VeggieDeselect(selection); break; }; totalPrice += veggies; pepperDisplay = "\tPeppers\t\t" + veggies.ToString("C") + "\n"; break;
                    case "0": return;

                    default: Console.WriteLine("Select vegetable using number keys or press 0 to proceed."); break;
                }
             
            } while (true);
        }

        private static void VeggieDeselect ( string deselect)
        {
                switch (deselect)
                {
                    case "1": totalPrice -= veggies; oliveDisplay = null; return;
                    case "2": totalPrice -= veggies; mushroomDisplay = null; return;
                    case "3": totalPrice -= veggies; onionDisplay = null; return;
                    case "4": totalPrice -= veggies; pepperDisplay = null; return;
                    case "0": return;

                    default: Console.WriteLine("Select vegetable or press 0 to proceed."); break;
                }
        }

        static double pizzaSauce = 1;

        private static void Sauce ()
        {
            Console.WriteLine("Sauce: (One is Required)");
            Console.Write("1. Traditional ($0) "); if (sauceDisplay == "\tTraditional\t\t") { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
            Console.Write("2. Garlic ($1) "); if (sauceDisplay == "\tGarlic\t\t" + pizzaSauce.ToString("C") + "\n") { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
            Console.Write("3. Oregano ($1) "); if (sauceDisplay =="\tOregano\t\t" + pizzaSauce.ToString("C") + "\n") { Console.WriteLine("Selected"); } else { Console.WriteLine(); };

            do
            {
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": sauceDisplay = "\tTraditional\t\t"; return;
                    case "2": totalPrice += pizzaSauce; sauceDisplay = "\tGarlic\t\t" + pizzaSauce.ToString("C") + "\n"; return;
                    case "3": totalPrice += pizzaSauce; sauceDisplay = "\tOregano\t\t" + pizzaSauce.ToString("C") + "\n"; return;

                    default: Console.WriteLine("Please pick a sauce."); break;
                }
            }
            while (true);

        }

        static double extraCheese = 1.50;

        private static void Cheese ()
        {
            Console.WriteLine("Cheese");
            Console.Write("1. Regular ($0) "); if (cheeseDisplay == "\tRegular cheese\t\t") { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
            Console.Write("2. Extra ($1.50) "); if (cheeseDisplay == "\tExtra cheese\t\t" + extraCheese.ToString("C")) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };

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
            Console.Write("1. Take out ($0) "); if (deliveryDisplay == "Take out\t\t" + takeOut.ToString("C")) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };
            Console.Write("2. Delivery ($2.50) "); if (deliveryDisplay == "Delivery\t\t" + deliver.ToString("C")) { Console.WriteLine("Selected"); } else { Console.WriteLine(); };

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

            Console.WriteLine("Meats:");

            Console.Write(meatDisplay = baconDisplay + hamDisplay + pepperoniDisplay + sausageDisplay);

            Console.Write("Vegatables:\n");

            Console.WriteLine(vegatableDisplay = oliveDisplay + mushroomDisplay + onionDisplay + pepperDisplay);

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

            // If the user selects yes they go through the whole order process
            if (Modify() == true)
            {
                totalPrice -= pizzaSize; 

                PizzaSize();

                Meats();

                Vegetables();

                if (sauceDisplay == "\tGarlic\t\t" + pizzaSauce.ToString("C") + "\n" || sauceDisplay == "\tOregano\t\t" + pizzaSauce.ToString("C") + "\n")
                {
                    totalPrice -= pizzaSauce;
                }

                Sauce();

                if (cheeseDisplay == "\tExtra cheese\t\t" + extraCheese.ToString("C"))
                {
                    totalPrice -= extraCheese;
                }

                Cheese();

                if (deliveryDisplay == "Delivery\t\t" + deliver.ToString("C"))
                {
                    totalPrice -= deliver;
                }

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

                // if the user chooses yes then pizza size gets substracted
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
