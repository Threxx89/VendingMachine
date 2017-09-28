using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Product
{
    public interface IProduct
    {
        string Name {get;}
        ProductType ProductType { get; }
        double Cost { get; }
    }
}