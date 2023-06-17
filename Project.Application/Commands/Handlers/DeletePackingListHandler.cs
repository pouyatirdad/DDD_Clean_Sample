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
	internal sealed class DeletePackingListHandler : ICommandHandler<DeletePackingList>
	{
		private readonly IPackingListRepository _repository;

		public DeletePackingListHandler(IPackingListRepository repository)
		{
			_repository = repository;
		}

		public async Task HandlerAsync(DeletePackingList command)
		{
			var packingList = await _repository.GetAsync(command.Id);

			if (packingList is null)
			{
				throw new PackingListNullException();
			}

			await _repository.DeleteAsync(packingList);
		}
	}
}
