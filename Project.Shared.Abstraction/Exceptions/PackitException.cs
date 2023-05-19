using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Abstraction.Exceptions
{
	public abstract class PackitException:Exception
	{
        protected PackitException(string message):base(message)
        {
            
        }
    }
}
