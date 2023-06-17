using Project.Domain.Entities;
using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Repositories
{
	public interface IpackingListRepository
	{
		Task<PackingList> GetAsync(PackingListId id);
		Task AddAsync(PackingList packingList);
		Task UpdateAsync(PackingList packingList);
		Task DeleteAsync(PackingList packingList);
	}
}
