using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Currency;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaVendingMachine VendingMachine = new SodaVendingMachine(CurrencyType.Yen);
            bool shouldClose = false;

            foreach (var product in VendingMachine.VendingMachineProducts)
            {
                Console.WriteLine(product.Key + " " + product.Value.Product.Name + " " + VendingMachine.Currency.Symbol+""+product.Value.Product.Cost );
            }

            VendingMachine.InsertMoney(new Money(CurrencyType.Yen, 1050));

            string value = Console.ReadLine();
            Console.WriteLine(VendingMachine.Buy(value)); 
            List<Denomination> change = VendingMachine.GiveChange();
            foreach (Denomination item in change)
            {
                Console.WriteLine(VendingMachine.Currency.Symbol + "" + item.Value);
            }

            Console.ReadKey();
        }
    }
}
