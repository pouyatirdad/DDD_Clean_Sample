using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Abstraction.Commands
{
	public interface ICommandHandler<TCommand> where TCommand :class, ICommand
	{
		Task HandlerAsync(TCommand command);
	}
}
