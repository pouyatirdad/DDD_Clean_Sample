using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class EmptyPackingListIdException : PackitException
	{
		public EmptyPackingListIdException() : base("Packing List Id can't be empty")
		{
		}
	}
}
