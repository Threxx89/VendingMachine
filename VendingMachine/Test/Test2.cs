using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Test
{
    internal class Test2
    {
        public string wheel = "wheel";
        public Test Test;

        public string GetWheel()
        {
            return wheel;
        }

        public string GetCar()
        {
            return Test.GetCar();
        }

        public Test2()
        {
            
        }
    }
}
