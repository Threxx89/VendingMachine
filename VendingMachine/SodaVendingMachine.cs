using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Currency;
using VendingMachine.Product;

namespace VendingMachine
{
    public class SodaVendingMachine : IVendingMachine
    {
        #region Private Members
        private ICurrency m_Currency;
        private double m_InsertedMoney;
        private Dictionary<string, Item> m_VendingMachineProducts;
        #endregion

        #region Properties
        public string Name
        {
            get { return "Soda Tron"; }
        }
    
        public Dictionary<string, Item> VendingMachineProducts
        {
            get { return m_VendingMachineProducts; }
        }

        public ICurrency Currency
        {
            get { return m_Currency; }
            set { m_Currency = value; }
        }
        #endregion

        #region Constructor
        public SodaVendingMachine(CurrencyType currency)
        {
            this.m_Currency = _GetCurrency(currency);
            _AddProducts();
        }
        #endregion

        #region Public Methods
        public IProduct Buy(string itemCode)
        {
            IProduct  selectedItem = VendingMachineProducts.FirstOrDefault(x => x.Key == itemCode).Value.Product;
            if (selectedItem != null)
            {
               m_InsertedMoney = m_InsertedMoney - selectedItem.Cost;
            } 

            return selectedItem;
        }

        public List<Denomination> GiveChange()
        {
            List<Denomination> change = new List<Denomination>();
            while (m_InsertedMoney > 0)
            {
                int currentValue;
                int previouseValue = 0;
                Denomination value = null;

                foreach (Denomination item in Currency.GetCurrencyDenominations())
                {
                    currentValue = (int)m_InsertedMoney / item.Value;
                    if (currentValue < previouseValue && currentValue > 0 || previouseValue == 0)
                    {
                        previouseValue = currentValue;
                        value = item;
                    }
                }
                m_InsertedMoney -= value.Value;
                change.Add(value);
            }

            return change;
        }

        public void InsertMoney(Money money)
        {
            if (money.CurrencyType == m_Currency.CurrencyType)
            {
                m_InsertedMoney += money.Amount;
            }
        }

        public bool Restock(Item item, int amount)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private void _AddProducts()
        {
            m_VendingMachineProducts = new Dictionary<string, Item>();
            m_VendingMachineProducts.Add("A1", new Item(new Soda("Coke", 170, ProductType.Soda), 32));
            m_VendingMachineProducts.Add("A2", new Item(new Soda("Fanta", 132, ProductType.Soda), 32));
            m_VendingMachineProducts.Add("A3", new Item(new Soda("Beer", 350, ProductType.Soda), 32));
        }

        private ICurrency _GetCurrency(CurrencyType currencySpecified)
        {
            switch (currencySpecified)
            {
                case CurrencyType.Rand:
                    return new Yen();
                case CurrencyType.Yen:
                    return new Yen();
                case CurrencyType.Euro:
                    return new Yen();
                default:
                    return new Yen();
            }
        }
        #endregion
    }
}
