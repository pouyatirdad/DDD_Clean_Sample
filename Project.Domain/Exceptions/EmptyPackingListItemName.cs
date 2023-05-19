using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class EmptyPackingListItemName : PackitException
	{
		public EmptyPackingListItemName() : base("packing item name can't be empty")
		{
		}
	}
}
