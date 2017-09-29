using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Currency;
using VendingMachine.Machine;
using VendingMachine.Menu;
using VendingMachine.Product;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaVendingMachine VendingMachine = new SodaVendingMachine(CurrencyType.Yen);
            CreatedMenu mainMenu = _GenerateMainMenu();
            mainMenu.DrawMenu();
            while (true)
            {

            }
            VendingMachine.InsertMoney(new Money(CurrencyType.Yen, Convert.ToInt32(Console.ReadLine())));

            string value = Console.Read();
            Console.WriteLine(VendingMachine.Buy(value)); 
            List<Denomination> change = VendingMachine.GiveChange();
            foreach (Denomination item in change)
            {
                Console.WriteLine(VendingMachine.Currency.Symbol + "" + item.Value);
            }

            Console.ReadKey();
        }

        private static CreatedMenu _GenerateMainMenu()
        {
            CreatedMenu mainMenu = new CreatedMenu();
            mainMenu.MenuItems.Add(new MenuItem(ConsoleKey.A, "Buy Item", _BuyItem));
            mainMenu.MenuItems.Add(new MenuItem(ConsoleKey.B, "Restock", _BuyItem));
            mainMenu.MenuItems.Add(new MenuItem(ConsoleKey.C, "Exit", _BuyItem));
            return mainMenu;
        }

        private static string _BuyItem()
        {
            return "buy me";
        }

        private static string _Exit()
        {
            return "Closed";
        }

        private static string _Restock()
        {
            return "has restocked";
        }
    }
}
