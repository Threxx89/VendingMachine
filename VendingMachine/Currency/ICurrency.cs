using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Currency;

namespace VendingMachine.Currency
{
   public interface ICurrency
    {
        string Name { get; }

        CurrencyType CurrencyType { get; }

        char Symbol { get; }

        IEnumerable<Denomination> GetCurrencyDenominations();
    }
}
