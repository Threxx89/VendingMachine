using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Currency
{
    public class Euro 
    {
        public string Name => "Euro";

        public CurrencyType CurrencyType => CurrencyType.Euro;

        public char Symbol => '€';

        public IEnumerable<Denomination> GetCurrencyDenominations()
        {
            return new List<Denomination>()
                        {
                            new Denomination("one",1),
                            new Denomination("five",5),
                            new Denomination("ten",10),
                            new Denomination("twenty",20),
                            new Denomination("fithy",50),
                            new Denomination("hundred",100)
                        };
        }
    }
}
