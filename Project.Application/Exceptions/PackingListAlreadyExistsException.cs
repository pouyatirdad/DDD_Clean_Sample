using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Exceptions
{
	internal class PackingListAlreadyExistsException : PackitException
	{
		public PackingListAlreadyExistsException(string name) : base($"packing list with name : {name} already exists")
		{
			Name = name;
		}

		public string Name { get; }
	}
}
