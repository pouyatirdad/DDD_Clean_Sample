using Project.Application.DTO;
using Project.Domain.Repositories;
using Project.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Queries.Handlers
{
	internal class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDTO>
	{
		private readonly IpackingListRepository _repository;

		public GetPackingListHandler(IpackingListRepository repository)
		{
			_repository = repository;
		}

		public async Task<PackingListDTO> HandleAsync(GetPackingList query)
		{
			var packingList = await _repository.GetAsync(query.Id);

			return packingList?.AsDTO();
		}
	}
}
