using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Exceptions
{
	internal class PackingListNullException : PackitException
	{
		public PackingListNullException() : base($"packing list not found")
		{
		}
	}
}
