using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Factories;
using Project.Domain.Policies;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application
{
	public static class Extensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddCommands();
			services.AddSingleton<IPackingListFactory,PackingListFactory>();

			services.Scan(b=>b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
			.AddClasses(c=>c.AssignableTo<IPackingItemsPolicy>())
			.AsImplementedInterfaces()
			.WithSingletonLifetime());

			return services;
		}
	}
}
