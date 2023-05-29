using Project.Application.DTO;
using Project.Application.Services;
using Project.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Queries.Handlers
{
	internal class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDTO>>
	{
		public Task<IEnumerable<PackingListDTO>> HandleAsync(SearchPackingList query)
		{
			throw new NotImplementedException();
		}
	}
}
