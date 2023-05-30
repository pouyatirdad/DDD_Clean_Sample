using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Factories;
using Project.Domain.Policies;
using Project.Shared.Commands;
using Project.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
	public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddQueries();


			return services;
		}
	}
}
