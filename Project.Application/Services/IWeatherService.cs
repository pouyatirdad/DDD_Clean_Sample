using Project.Application.DTO.External;
using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services
{
	public interface IWeatherService
	{
		Task<WeatherDTO> GetWeatherAsync(Localization localization);
	}
}
