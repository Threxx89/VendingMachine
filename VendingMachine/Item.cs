using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Product;

namespace VendingMachine
{
   public class Item
    {
        #region Private
        private int m_Stock;
        private IProduct m_Product;
        #endregion

        #region Properties
        public int Stock
        {
            get
            {
                return m_Stock;
            }
        }

        public IProduct Product
        {
            get
            {
                return m_Product;
            }
        }
        #endregion

        #region Constructor
        public Item(IProduct product, int stock)
        {
            this.m_Stock = stock;
            this.m_Product = product;
        }
        #endregion

        #region Public Methods
        public bool AddStock(Item item, int amount)
        {
            if (m_Product.Name.Equals(item.Product))
            {
                m_Stock =+ amount;
                return true;
            }
            return false;
        }
        #endregion
    }
}
