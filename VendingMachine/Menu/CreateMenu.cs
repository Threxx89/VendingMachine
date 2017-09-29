using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Menu
{
   public class CreatedMenu
    {
        #region Private Members
        private List<MenuItem> m_MenuItems;
        private bool m_ShouldExit;
        #endregion
    
        #region Properties
        public List<MenuItem> MenuItems
        {
            get { return m_MenuItems; }
        }

        public bool ShouldClose
        {
            get
            {
                return m_ShouldExit;
            }
        }
        #endregion

        public CreatedMenu()
        {
            m_MenuItems = new List<MenuItem>();
        }

        public void DrawMenu()
        {
            foreach (MenuItem item in m_MenuItems)
            {
                Console.WriteLine(string.Format("{0} : {1}.",item.ConsoleKey,item.Name));
            }
        }

        private void PerformMenuItem(ConsoleKeyInfo keyInfo)
        {
            MenuItem selectedItem = MenuItems.FirstOrDefault(x => x.ConsoleKey == keyInfo.Key);
            if (selectedItem != null)
            {
                Console.WriteLine(selectedItem.Execute());
            }
        }
    }
}
