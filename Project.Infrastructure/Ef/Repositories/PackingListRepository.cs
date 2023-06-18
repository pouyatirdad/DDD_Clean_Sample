using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Repositories;
using Project.Domain.ValueObjects;
using Project.Infrastructure.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Ef.Repositories
{
	internal sealed class PackingListRepository : IPackingListRepository
	{
		private readonly DbSet<PackingList> _packingLists;
		private readonly WriteDbContext _writeDbContext;

		public PackingListRepository(WriteDbContext writeDbContext)
		{
			_packingLists = writeDbContext.PackingLists;
			_writeDbContext = writeDbContext;
		}


		public async Task AddAsync(PackingList packingList)
		{
			await _packingLists.AddAsync(packingList);
			await _writeDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(PackingList packingList)
		{
			_packingLists.Remove(packingList);
			await _writeDbContext.SaveChangesAsync();
		}

		public Task<PackingList> GetAsync(PackingListId id)
		{
			return _packingLists.Include("_items").SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task UpdateAsync(PackingList packingList)
		{
			_packingLists.Update(packingList);
			await _writeDbContext.SaveChangesAsync();
		}
	}
}
