using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Services;
using Project.Infrastructure.Ef;
using Project.Infrastructure.Services;
using Project.Shared.Queries;

namespace Project.Infrastructure
{
	public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddPostgres(configuration);
			services.AddQueries();
			services.AddSingleton<IWeatherService, WeatherService>();

			return services;
		}
	}
}
