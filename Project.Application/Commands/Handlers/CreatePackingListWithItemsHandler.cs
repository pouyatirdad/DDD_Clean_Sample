using Project.Application.Exceptions;
using Project.Application.Services;
using Project.Domain.Factories;
using Project.Domain.Repositories;
using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Commands.Handlers
{
	public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
	{
		private readonly IpackingListRepository _repository;
		private readonly IPackingListFactory _factory;
		private readonly IPackingListReadService _readService;

		public CreatePackingListWithItemsHandler(IpackingListRepository repository, IPackingListFactory factory, IPackingListReadService readService)
		{
			_repository = repository;
			_factory = factory;
			_readService = readService;
		}

		public async Task HandlerAsync(CreatePackingListWithItems command)
		{
			var (id, name, days, gender, localization) = command;

			if (await _readService.ExistsByNameAsync(name))
			{
				throw new PackingListAlreadyExistsException(name);
			}


		}
	}
}
