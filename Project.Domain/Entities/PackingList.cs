using Project.Domain.Exceptions;
using Project.Domain.ValueObjects;
using Project.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
	public class PackingList : AggregateRoot<PackingListId>
	{
		public Guid Id { get; private set; }

		private PackingListName _name;
		private Localization _localization;

		private readonly LinkedList<PackingItem> _packingItems = new();

		internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> packingItems)
		{
			Id = id;
			_name = name;
			_localization = localization;
		}

		public void AddItem(PackingItem item)
		{
			bool existitem = _packingItems.Any(x => x.Name == item.Name);

			if (existitem)
			{
				throw new PackingItemAlreadyExistsException(_name, item.Name);
			}

			_packingItems.AddLast(item);
		}

	}
}
