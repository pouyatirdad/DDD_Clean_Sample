using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class PackingItemNotFoundException : PackitException
	{
		public string ItemName { get; }
		public PackingItemNotFoundException(string itemName) : base($"Packing item {itemName} was not found.")
		{
			ItemName = itemName;
		}
	}
}
