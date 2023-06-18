using Project.Application.Exceptions;
using Project.Domain.Repositories;
using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Commands.Handlers
{
	internal sealed class TakeItemHandler : ICommandHandler<TakeItem>
	{
		private readonly IPackingListRepository _repository;

		public TakeItemHandler(IPackingListRepository repository)
		{
			_repository = repository;
		}

		public async Task HandleAsync(TakeItem command)
		{
			var packingList = await _repository.GetAsync(command.ListId);

			if (packingList is null)
			{
				throw new PackingListNullException();
			}

			packingList.PackItem(command.Name);

			await _repository.UpdateAsync(packingList);
		}
	}
}
