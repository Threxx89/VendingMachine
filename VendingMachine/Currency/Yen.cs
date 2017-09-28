using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Currency
{
    public class Yen : ICurrency
    {
        public string Name
        {
            get
            {
                return "Yen";
            }
        }

        public CurrencyType CurrencyType
        {
            get
            {
                return CurrencyType.Yen;
            }
        }

        public char Symbol
        {
            get { return '¥'; }
        }

        public IEnumerable<Denomination> GetCurrencyDenominations()
        {
            return new List<Denomination>()
                        {
                            new Denomination("ichien",1),
                            new Denomination("goen",5),
                            new Denomination("juuen",10),
                            new Denomination("gojuuen",50),
                            new Denomination("hyakuen",100),
                            new Denomination("gohaykuen",500)
                        };
        }

        public override string ToString()
        {
            return Name;
        }

        public Yen()
        {

        }
    }
}
