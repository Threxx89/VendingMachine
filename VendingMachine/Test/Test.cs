using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Test
{
    internal class Test
    {
        public string car = "car";
        public Test2 Test2;

        public string GetCar()
        {
            return car;
        }

        public string GetWheel()
        {
            return Test2.GetWheel();
        }

        public Test()
        {
            
        }
    }
}
