using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Services;
using Project.Infrastructure.Ef;
using Project.Infrastructure.Logging;
using Project.Infrastructure.Services;
using Project.Shared.Abstraction.Commands;
using Project.Shared.Queries;

namespace Project.Infrastructure
{
	public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSql(configuration);
			services.AddQueries();
			services.AddSingleton<IWeatherService, WeatherService>();

			services.TryDecorate(typeof(ICommandHandler<>),typeof(LoggingCommandHandlerDecorator<>));

			return services;
		}
	}
}
