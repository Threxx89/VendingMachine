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
        private static bool m_ShouldExit = false;
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
            set
            {
                m_ShouldExit = true;
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
                Console.WriteLine(string.Format("{0} : {1}.",item.ConsoleKey,item.Item.ToString()));
            }
        }

        public object PerformMenuItem(ConsoleKeyInfo keyInfo)
        {
            MenuItem selectedItem = MenuItems.FirstOrDefault(x => x.ConsoleKey == keyInfo.Key);
            if (selectedItem != null)
            {
               return selectedItem.Execute();
            }
            return string.Empty;
        }

        public static CreatedMenu _GenerateMenu<T>(List<T> possibleMenuItem)
        {
            int counter = 65;
            CreatedMenu newMenu = new CreatedMenu();
            foreach (T item in possibleMenuItem)
            {
                newMenu.MenuItems.Add(new MenuItem((ConsoleKey)ConsoleKey.Parse(typeof(ConsoleKey), counter.ToString()), (T)item));
                counter++;
            }
            newMenu.MenuItems.Add(new MenuItem((ConsoleKey)ConsoleKey.Parse(typeof(ConsoleKey), counter.ToString()), "Exit",_Exit));
            return newMenu;
        }

        private static object _Exit()
        {
            m_ShouldExit = true;
            return null;
        }
    }
}
