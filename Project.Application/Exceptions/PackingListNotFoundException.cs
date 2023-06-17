using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Exceptions
{
	public class PackingListNotFoundException : PackitException
	{
		public Guid Id { get; }

		public PackingListNotFoundException(Guid id) : base($"Packing list with ID '{id}' was not found.")
			=> Id = id;
	}
}
