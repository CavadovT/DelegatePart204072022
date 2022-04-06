using System;
using System.Collections.Generic;
using System.Text;

namespace UtulsLibrary.Exceptions
{
    public class CapacityLimitException:Exception
    {
        public CapacityLimitException(string message) : base(message)
        {

        }
    }
}
