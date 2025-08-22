using System;

namespace ShoppingSystemProject
{
    internal class Program
    {
        // CardItems contains all the products I added
        static public List<string> CartItems = new List<string>();

        // Storing user actions
        static public Stack<string> Actions = new Stack<string>();

        // Store the last item name you want to remove or add
        static public string LastItem = "";

        // ItemsPrices contains all products with their names and prices
        static public Dictionary<string, double> ItemsPrices = new Dictionary<string, double>()
        {
           { "Headphones", 1200 },
           { "Smartphone", 8000 },
           { "Tablet", 4500 },
           { "Smartwatch", 2000 },
           { "Printer", 3500 },
           { "Keyboard", 600 },
           { "Mouse", 400 },
           { "Monitor", 5000 },
           { "Speaker", 1500 },
           { "Router", 1000 }
        };
        static void Main(string[] args)
        {
            Console.WriteLine(" \tWelcome to my Shopping System");
            ViewOptions();
            while (true)
            {
                Console.Write(" Enter Your choice from 0 to 6 : ");

                bool CheckChoice = int.TryParse(Console.ReadLine(), out int Choice);
                Console.WriteLine("============================================");

                if (CheckChoice)
                {
                    switch (Choice)
                    {
                        case 0:
                            ViewOptions();
                            break;
                        case 1:
                            AddItem();
                            break;
                        case 2:
                            ViewCart();
                            break;
                        case 3:
                            RemoveItem();
                            break;
                        case 4:
                            Checkout();
                            break;
                        case 5:
                            UndoAction();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine("Your choice must be between 0 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! .");

                }
            }
        }
        private static void ViewOptions()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("0 - view options");
            Console.WriteLine("1 - Add item to cart");
            Console.WriteLine("2 - view cart items");
            Console.WriteLine("3 - Remove item from cart");
            Console.WriteLine("4 - Checkout");
            Console.WriteLine("5 - Undo last action");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("============================================");
        }
        private static void AddItem()
        {
            //print avilable items 
            Console.WriteLine("Available items:");
            Console.WriteLine("----------------");
            int i = 1;
            foreach (var product in ItemsPrices)
            {
                Console.WriteLine($"[product {i}] -  name: {product.Key} && Price: {product.Value}");
                Console.WriteLine("---------------------------------------------");

                i++;
            }

            //add item
            Console.Write("Please enter product name:");
            string item = Console.ReadLine();

            if (!string.IsNullOrEmpty(item))
            {

                if (ItemsPrices.ContainsKey(item))
                {
                    CartItems.Add(item);
                    Actions.Push($"Item {item} added to cart");
                    LastItem = item;
                    Console.WriteLine($"{item} added successfully.");
                    Console.WriteLine("============================================");

                }
                else
                {
                    Console.WriteLine($"{item} is not available to add.");
                    Console.WriteLine("============================================");

                }
            }
            else
            {
                Console.WriteLine("Invalid input: item name cannot be empty.");
                Console.WriteLine("============================================");

            }

        }

        private static void ViewCart()
        {
            if (CartItems.Count == 0)
            {
                Console.WriteLine("Cart is empty");

            }
            else
            {
                Console.WriteLine("Your cart items are:");
                Console.WriteLine("----------------------");
                int i = 1;
                foreach (var item in GetCartPrices())
                {
                    Console.WriteLine($"[Product {i++}] - name: {item.Item1} && Price: {item.Item2}");
                    Console.WriteLine("---------------------------------------------");
                }
            }

        }
        private static IEnumerable<Tuple<string, double>> GetCartPrices()
        {
            //storeprice for all products in cart
            var CartPrices = new List<Tuple<string, double>>();

            foreach (var item in CartItems)
            {
                bool foundprice = ItemsPrices.TryGetValue(item, out double price);
                if (foundprice)
                {
                    var itemprice = new Tuple<string, double>(item, price);
                    CartPrices.Add(itemprice);
                }

            }
            return CartPrices;
        }

        private static void RemoveItem()
        {
            ViewCart();//print all items in card  

            if (CartItems.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.Write("Please select item to remove it from the cart: ");
                string itemtoremove = Console.ReadLine();
                if (CartItems.Contains(itemtoremove))
                {
                    CartItems.Remove(itemtoremove);
                    Actions.Push($"Item {itemtoremove} Removed from cart");
                    LastItem = itemtoremove;
                    Console.WriteLine($"{itemtoremove} is removed successfully.");
                    Console.WriteLine("============================================");

                }
                else
                {
                    Console.WriteLine($"{itemtoremove} doesn't exist in shoping cart.");
                    Console.WriteLine("============================================");

                }
            }
        }
        private static void Checkout()
        {
            if (CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                double TotalPrice = 0;

                Console.WriteLine("Your cart items are:");
                Console.WriteLine("----------------------");
                int i = 1;
                foreach (var item in GetCartPrices())
                {
                    TotalPrice += item.Item2;//sum all prices
                    Console.WriteLine($"[Product {i++}] - name: {item.Item1} && Price: {item.Item2}");
                    Console.WriteLine("----------------------------------------------------");

                }
                Console.WriteLine($"Total price to pay: {TotalPrice}$");
                Console.WriteLine("Proceed to payment — thanks for shopping with us!");
                Console.WriteLine("=====================================================");
                CartItems.Clear();
                Actions.Push("Checkout");
            }
        }

        private static void UndoAction()
        {
            if (Actions.Count > 0)
            {
                string LastActon = Actions.Pop();
                Console.WriteLine($"Your last action is [{LastActon}]");

                if (LastActon.Contains("Removed"))
                {
                    CartItems.Add(LastItem);
                }
                else if (LastActon.Contains("added"))
                {
                    CartItems.Remove(LastItem);

                }
                else
                {
                    Console.WriteLine("Checkout cannot be undone. Please ask for a refund.");
                }
            }
            else
            {
                Console.WriteLine("No actions available to undo");
            }
        }

    }
}
