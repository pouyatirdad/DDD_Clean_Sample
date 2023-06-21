using Microsoft.Extensions.Logging;
using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Logging
{
	internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class,ICommand
	{
		private readonly ICommandHandler<TCommand> _handler;
		private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;

		public LoggingCommandHandlerDecorator(ILogger<LoggingCommandHandlerDecorator<TCommand>> logger, ICommandHandler<TCommand> handler)
		{
			_logger = logger;
			_handler = handler;
		}

		public async Task HandleAsync(TCommand command)
		{
			var commandType = command.GetType().Name;

			try
			{
				_logger.LogInformation($"Started processing {commandType} command.");
				await _handler.HandleAsync( command );
				_logger.LogInformation($"Finished processing {commandType} command.");
			}
			catch (Exception e)
			{
				_logger.LogError($"Failed to process {commandType} command.");
				throw;
			}
		}
	}
}
