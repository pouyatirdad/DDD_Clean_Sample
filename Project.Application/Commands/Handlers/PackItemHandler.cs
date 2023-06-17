using Project.Application.Exceptions;
using Project.Domain.Repositories;
using Project.Domain.ValueObjects;
using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Commands.Handlers
{
	internal sealed class PackItemHandler : ICommandHandler<PackItem>
	{

		private readonly IpackingListRepository _repository;

		public PackItemHandler(IpackingListRepository repository)
		{
			_repository = repository;
		}

		public async Task HandlerAsync(PackItem command)
		{
			var packingList = await _repository.GetAsync(command.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNullException();
			}

			packingList.PackItem(command.Name);

			await _repository.UpdateAsync(packingList);
		}
	}
}
