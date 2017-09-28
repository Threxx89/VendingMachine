using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Currency
{
   public class Money
    {
        #region Private Members
        private double m_Amount;
        private CurrencyType m_CurrencyType;
        #endregion

        #region Properties
        public double Amount { get => m_Amount; set => m_Amount = value; }
        public CurrencyType CurrencyType { get => m_CurrencyType; set => m_CurrencyType = value; }
        #endregion

        public Money(CurrencyType currency , double amount)
        {
            this.m_CurrencyType = currency;
            this.Amount = amount;
        }

    }
}
