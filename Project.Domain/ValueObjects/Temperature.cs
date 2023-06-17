using Project.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.ValueObjects
{
	public record Temperature
	{
		public double Value { get; }
		public Temperature(double value)
		{
			if (value is < -100 or > 100)
			{
				throw new InvalidTemperatureException(value);
			}

			Value = value;
		}

		public static implicit operator double(Temperature temp) => temp.Value;
		public static implicit operator Temperature(double temp) => new(temp);
	}
}
