using Microsoft.EntityFrameworkCore;
using Project.Application.Services;
using Project.Infrastructure.Ef.Contexts;
using Project.Infrastructure.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Ef.Services
{
	internal class PackingListReadService : IPackingListReadService
	{
		private readonly DbSet<PackingListReadModel> _packingLists;

		public PackingListReadService(ReadDbContext context)
		{
			_packingLists = context.PackingLists;
		}

		public Task<bool> ExistsByNameAsync(string name)
		{
			return _packingLists.AnyAsync(x=>x.Name == name);
		}
	}
}
