using Project.Domain.Events;
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
		public PackingListId Id { get; private set; }

		private PackingListName _name;
		private Localization _localization;

		private readonly LinkedList<PackingItem> _packingItems = new();

		private PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> packingItems)
			:this(id,name,localization)
		{
			_packingItems = packingItems;
		}

		private PackingList()
		{

		}

		internal PackingList(PackingListId id, PackingListName name, Localization localization)
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
			AddEvent(new PackingItemAdded(this, item));
		}

		public void AddItems(IEnumerable<PackingItem> items)
		{
			foreach (var item in items)
			{
				AddItem(item);
			}
		}

		public void PackItem(string itemName)
		{
			var item = GetItem(itemName);
			var packedItem = item with { IsPacked = true};

			_packingItems.Find(item).Value=packedItem;
			AddEvent(new PackingItemPacked(this,item));
		}

		public void RemoveItem(string itemName)
		{
			var item = GetItem(itemName);
			_packingItems.Remove(item);
			AddEvent(new PackingItemRemoved(this,item));
		}

		private PackingItem GetItem(string itemName)
		{
			var item = _packingItems.SingleOrDefault(x => x.Name == itemName);
			if (item is null)
			{
				throw new PackingItemNotFoundException(itemName);
			}

			return item;
		}
	}
}
