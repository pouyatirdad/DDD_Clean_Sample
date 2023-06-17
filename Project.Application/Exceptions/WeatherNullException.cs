using Project.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Exceptions
{
	internal class WeatherNullException : PackitException
	{
		public WeatherNullException() : base($"weather is null")
		{
		}
	}
}
