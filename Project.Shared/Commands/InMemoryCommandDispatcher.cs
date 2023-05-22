﻿using Microsoft.Extensions.DependencyInjection;
using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Commands
{
	public class InMemoryCommandDispatcher : ICommandDispatcher
	{
		private readonly IServiceProvider _serviceProvider;

		public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		async Task ICommandDispatcher.DispatchAsync<TCommand>(TCommand command)
		{
			using var scope = _serviceProvider.CreateScope();
			var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

			await handler.HandlerAsync(command);
		}
	}
}
