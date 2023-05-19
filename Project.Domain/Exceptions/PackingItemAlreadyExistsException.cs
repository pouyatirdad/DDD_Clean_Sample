using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class PackingItemAlreadyExistsException : PackitException
	{
		public string ListName { get; }
		public string ItemName { get; }

		public PackingItemAlreadyExistsException(string listName,string itemName) 
			: base($"Packing list : {listName} , already defined item {itemName}")
		{
			ListName = listName;
			ItemName = itemName;
		}
	}
}
