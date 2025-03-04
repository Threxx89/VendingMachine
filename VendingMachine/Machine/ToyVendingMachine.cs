﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Currency;
using VendingMachine.Product;

namespace VendingMachine.Machine
{
    public class ToyVendingMachine : IVendingMachine
    {
        #region Private Members
        private ICurrency m_Currency;
        private double m_InsertedMoney;
        private List<Item> m_VendingMachineProducts;
        #endregion

        #region Properties
        public string Name
        {
            get { return "Soda Tron"; }
        }

        public List<Item> VendingMachineProducts
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
        public ToyVendingMachine(CurrencyType currency)
        {
            this.m_Currency = _GetCurrency(currency);
            _AddProducts();
        }
        #endregion

        #region Public Methods
        public IProduct Buy(IProduct selectedProduct)
        {
                IProduct selectedItem = VendingMachineProducts.FirstOrDefault(x => x.Product.Name == selectedProduct.Name).Product;
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
                int previousValue = 0;
                Denomination value = null;

                foreach (Denomination item in Currency.GetCurrencyDenominations())
                {
                    currentValue = (int)m_InsertedMoney / item.Value;
                    if (currentValue < previousValue && currentValue > 0 || previousValue == 0)
                    {
                        previousValue = currentValue;
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
                UpdateMoney(money);
            }
        }

        public void UpdateMoney(Money money)
        {
            m_InsertedMoney = money.Amount *2 + m_InsertedMoney;
        }

        public bool Restock(IProduct product, int amount)
        {
            return VendingMachineProducts.FirstOrDefault(x => x.Product.Name == product.Name).AddStock(product, amount);
        }
        #endregion

        #region Private Methods
        private void _AddProducts()
        {
            m_VendingMachineProducts = new List<Item>();
            m_VendingMachineProducts.Add(new Item(new Soda("Pokemon", 170, ProductType.Toy), 32));
            m_VendingMachineProducts.Add(new Item(new Soda("Car", 132, ProductType.Toy), 32));
            m_VendingMachineProducts.Add(new Item(new Soda("Bear", 350, ProductType.Toy), 32));
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
                    return (ICurrency)new Euro();
                default:
                    return new Yen();
            }
        }
        #endregion
    }
}

