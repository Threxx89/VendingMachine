using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VendingMachine
{
    public class VendingMachineException : Exception
    {
        public VendingMachineException()
        {
        }

        public VendingMachineException(string message) : base(message)
        {
        }

        public VendingMachineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VendingMachineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
