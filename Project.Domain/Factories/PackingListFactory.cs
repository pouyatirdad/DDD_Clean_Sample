using Project.Domain.Consts;
using Project.Domain.Entities;
using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Factories
{
	public class PackingListFactory : IPackingListFactory
	{
		public PackingList Create(PackingListId id, PackingListName name, Localization localization)
		{
			throw new NotImplementedException();
		}

		public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender, Temperature temperature, Localization localization)
		{
			throw new NotImplementedException();
		}
	}
}
