using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Currency;
using VendingMachine.Product;

namespace VendingMachine.Machine
{
    public interface IVendingMachine
    {
        string Name { get; }

        List<Item> VendingMachineProducts { get;}

        IProduct Buy(IProduct itemCode);

        void InsertMoney(Money money);

        List<Denomination> GiveChange();

        bool Restock(IProduct product, int amount);

        ICurrency Currency { get; set; }
    }
}
