using Project.Application.DTO.External;
using Project.Application.Services;
using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Services
{
	internal class WeatherService : IWeatherService
	{
		public Task<WeatherDTO> GetWeatherAsync(Localization localization)
		{
			return Task.FromResult(
				new WeatherDTO(new Random().Next(5,30))
				);
		}
	}
}
