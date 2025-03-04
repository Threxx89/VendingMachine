using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VendingMachine.Currency;
using VendingMachine.Machine;
using VendingMachine.Menu;
using VendingMachine.Product;

namespace VendingMachine
{
    class Program
    {
       public static SodaVendingMachine VendingMachine = null;
        public static CreatedMenu MainMenu = null;
        static void Main(string[] args)
        {
            VendingMachine = new SodaVendingMachine(CurrencyType.Yen);
            MainMenu = _GenerateMainMenu();
            MainMenu.DrawMenu();
            while (!MainMenu.ShouldClose)
            {
                Console.WriteLine(MainMenu.PerformMenuItem(Console.ReadKey()));
            }
            Console.WriteLine("Press Any Key To Close....");
            Console.ReadKey();
        }

        private static CreatedMenu _GenerateMainMenu()
        {
            CreatedMenu mainMenu = new CreatedMenu();
            mainMenu.MenuItems.Add(new MenuItem(ConsoleKey.A, "Buy Item", _BuyItem));
            mainMenu.MenuItems.Add(new MenuItem(ConsoleKey.B, "Restock", _Restock));
            mainMenu.MenuItems.Add(new MenuItem(ConsoleKey.C, "Exit", _Exit));
            return mainMenu;
        }

        private static string _BuyItem()
        {
            CreatedMenu productMenu = CreatedMenu._GenerateMenu<Item>(VendingMachine.VendingMachineProducts);
           
            while (!productMenu.ShouldClose)
            {
            Console.Clear();
            productMenu.DrawMenu();
            Console.WriteLine("Please insert money...");
            Money insertedMoney = new Money(VendingMachine.Currency.CurrencyType, Convert.ToInt32(Console.ReadLine()));
            VendingMachine.InsertMoney(insertedMoney);

                Console.WriteLine("Please select item...");
                Item productItem = (Item)productMenu.PerformMenuItem(Console.ReadKey());
                if (productItem != null)
                {
                    Console.WriteLine(VendingMachine.Buy(productItem.Product));
                }
                List<Denomination> change = VendingMachine.GiveChange();
                Console.WriteLine("Giving Change.");
                foreach (Denomination changeItem in change)
                {
                    Console.WriteLine(string.Format("{0}{1}", VendingMachine.Currency.Symbol, changeItem.Value));
                }

                Console.WriteLine("Transaction Completed");
                Thread.Sleep(3000);
            }
            return "Exiting Buy Menu";
        }

        private static string _Exit()
        {
            MainMenu.ShouldClose = true;
            return "Exting Application";
        }

        private static string _Restock()
        {
            CreatedMenu productMenu = CreatedMenu._GenerateMenu<Item>(VendingMachine.VendingMachineProducts);

            while (!productMenu.ShouldClose)
            {
                Console.Clear();
                productMenu.DrawMenu();
                Console.WriteLine("Please select item to restock ...");
                Item productItem = (Item)productMenu.PerformMenuItem(Console.ReadKey());
                Console.WriteLine("Restock amount ...");
                int amount = Int32.Parse(Console.ReadLine());
                VendingMachine.Restock(productItem.Product,amount);
            }
            return "Exting Restock Menu";
        }

        private static string _Restocked(Item productItem)
        {

            int amount = Int32.Parse(Console.ReadLine());
            VendingMachine.Restock(productItem.Product, amount);

            return "Exting Restock Menu";
        }
    }
}
