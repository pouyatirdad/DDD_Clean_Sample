using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class EmptyPackingListNameException : PackitException
	{
		public EmptyPackingListNameException() : base("packing list name can't be empty")
		{
		}
	}
}
