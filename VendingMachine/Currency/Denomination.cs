using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Currency
{
    public class Denomination
    {
        #region Private Members
        private string m_Name;
        private int m_Value;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public int Value
        {
            get
            {
                return m_Value;
            }
        }
        #endregion

        #region Constructor
        public Denomination(string name, int value)
        {
            this.m_Name = name;
            this.m_Value = value;
        }
        #endregion
    }
}
