using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Menu
{
  public  class MenuItem
    {
        #region Private Members
        private ConsoleKey m_ConsoleKey;
        private object m_Item;
        private Func<object> m_Execute;
        #endregion

        #region Properties
        public ConsoleKey ConsoleKey
        {
            get { return m_ConsoleKey; }
        }

        public object Item
        {
            get { return m_Item; }
        }

        public Func<object> Execute
        {
            get { return m_Execute; }
        }

        public bool HasAction
        {
            get
            {
                if (m_Execute == null)
                {
                    return false;
                }
                else
                    return true;
            }

        }
        #endregion

        #region Consturctor
        public MenuItem(ConsoleKey consoleKey, object product)
        {
            m_ConsoleKey = consoleKey;
            m_Item = product;
            m_Execute = _GetMenuItem;
        }

        public MenuItem(ConsoleKey consoleKey, object product, Func<object> excutable)
        {
            m_ConsoleKey = consoleKey;
            m_Item = product;
            m_Execute = excutable;
        }
        #endregion

        private object _GetMenuItem()
        {
            return this.m_Item;
        }

    }
}
