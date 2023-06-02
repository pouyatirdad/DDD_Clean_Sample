using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Ef.Contexts;
using Project.Infrastructure.Ef.Options;
using Project.Shared.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Ef
{
	internal static class Extensions
	{
		public static IServiceCollection AddPostgres(this IServiceCollection services,IConfiguration configuration)
		{
			var options = configuration.GetOptions<PostgresOptions>("Postgres");

			services.AddDbContext<ReadDbContext>(
				x=>x.UseNpgsql(options.ConnectionString));

			services.AddDbContext<WriteDbContext>(
				x => x.UseNpgsql(options.ConnectionString));

			return services;
		}
	}
}
