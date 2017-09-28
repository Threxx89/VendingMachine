using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Product
{
    public class Soda : IProduct
    {
        #region Private Member
        private string m_Name;
        private ProductType m_ProductType;
        private double m_Cost;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public ProductType ProductType
        {
            get
            {
                return m_ProductType;
            }
        }

        public double Cost
        {
            get
            {
                return m_Cost;
            }
        }
        #endregion

        #region Constructor
        public Soda(string name, int cost, ProductType productType)
        {
            this.m_Name = name;
            this.m_Cost = cost;
            this.m_ProductType = ProductType;
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
