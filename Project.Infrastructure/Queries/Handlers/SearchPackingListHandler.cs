using Microsoft.EntityFrameworkCore;
using Project.Application.DTO;
using Project.Application.Queries;
using Project.Infrastructure.Ef.Contexts;
using Project.Infrastructure.Ef.Models;
using Project.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Queries.Handlers
{
	internal class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDTO>>
	{
		private readonly DbSet<PackingListReadModel> _packingLists;

		public SearchPackingListHandler(ReadDbContext context)
		{
			_packingLists = context.PackingLists;
		}
		public async Task<IEnumerable<PackingListDTO>> HandleAsync(SearchPackingList query)
		{
			var dbQuery = _packingLists.Include(x => x.items).AsQueryable();

			if (query.SearchText is not null)
			{
				dbQuery = dbQuery.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.Name, $"%{query.SearchText}%"));
			}

			return await dbQuery.Select(x=>x.AsDTO()).AsNoTracking().ToListAsync();
		}
	}
}
