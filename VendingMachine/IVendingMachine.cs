using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Currency;
using VendingMachine.Product;

namespace VendingMachine
{
    public interface IVendingMachine
    {
        string Name { get; }

        Dictionary<string, Item> VendingMachineProducts { get;}

        IProduct Buy(string itemCode);

        void InsertMoney(Money money);

        List<Denomination> GiveChange();

        bool Restock(Item item, int amount);

        ICurrency Currency { get; set; }
    }
}
