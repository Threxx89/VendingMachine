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
       public static SodaVendingMachine VendingMachine = null;

        static void Main(string[] args)
        {
            VendingMachine = new SodaVendingMachine(CurrencyType.Yen);
            CreatedMenu mainMenu = _GenerateMainMenu();
            mainMenu.DrawMenu();
            while (!mainMenu.ShouldClose)
            {
                mainMenu.PerformMenuItem(Console.ReadKey());
            }
            VendingMachine.InsertMoney(new Money(CurrencyType.Yen, Convert.ToInt32(Console.ReadLine())));


           // Console.WriteLine(VendingMachine.Buy(value)); 
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
            Console.WriteLine("Please insert money");
            Money insertedMoney = new Money(VendingMachine.Currency.CurrencyType, Convert.ToInt32(Console.ReadLine()));
            VendingMachine.InsertMoney(insertedMoney);

         
                //productMenu.PerformMenuItem(Console.ReadKey());
                Console.WriteLine("EnterItemCode");
                Console.WriteLine(VendingMachine.Buy(Console.ReadLine()));
                List<Denomination> change = VendingMachine.GiveChange();
                foreach (Denomination changeItem in change)
                {
                    Console.WriteLine(string.Format("{0}{1}",VendingMachine.Currency.Symbol,changeItem.Value));
                }
                Console.WriteLine("Press any button to continue .....");
                Console.ReadKey();
            }
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
