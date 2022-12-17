using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Exceptions
{
    [Serializable]
    public class UnwantedBehaviourException: Exception
    {
        public UnwantedBehaviourException(string message):base(message)
        {
  
        }

    }
}
