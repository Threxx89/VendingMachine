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
        private string m_Name;
        private Func<string> m_Execute;
        #endregion

        #region Properties
        public ConsoleKey ConsoleKey
        {
            get { return m_ConsoleKey; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public Func<string> Execute
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
        public MenuItem(ConsoleKey consoleKey, string name)
        {
            m_ConsoleKey = consoleKey;
            m_Name = name;
        }

        public MenuItem(ConsoleKey consoleKey, string name, Func<string> excutable)
        {
            m_ConsoleKey = consoleKey;
            m_Name = name;
            m_Execute = excutable;
        }
        #endregion


    }
}
