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
	internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
	{
		private readonly IpackingListRepository _repository;

		public AddPackingItemHandler(IpackingListRepository repository)
		{
			_repository = repository;
		}

		public async Task HandlerAsync(AddPackingItem command)
		{
			var packingList = await _repository.GetAsync(command.PackingListId);

			if (packingList is null)
			{
				throw new PackingListNullException();
			}

			var packingItem = new PackingItem(command.Name,command.Qantity);
			packingList.AddItem(packingItem);

			await _repository.UpdateAsync(packingList);
		}
	}
}
