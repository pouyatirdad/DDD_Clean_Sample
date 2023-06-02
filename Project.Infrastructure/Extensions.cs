using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Ef;
using Project.Shared.Queries;

namespace Project.Infrastructure
{
	public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddPostgres(configuration);
			services.AddQueries();

			return services;
		}
	}
}
