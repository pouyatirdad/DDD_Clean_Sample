using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class InvalidTravelDaysException : PackitException
	{
		public InvalidTravelDaysException(ushort days) : base($"value {days} is invalid for travel days")
		{
			Days = days;
		}

		public ushort Days { get; }
	}
}
