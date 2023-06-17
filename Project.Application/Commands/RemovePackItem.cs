using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Commands
{
	internal record RemovePackItem(Guid PackingListId, string Name) : ICommand;
}
