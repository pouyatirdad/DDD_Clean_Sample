using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Exceptions
{
	public class InvalidTemperatureException : PackitException
	{
		public InvalidTemperatureException(double temp) : base($"the temp {temp} is invalid")
		{
			Temp = temp;
		}

		public double Temp { get; }
	}
}
