﻿using Project.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.ValueObjects
{
	public record PackingItem
	{
        public string Name { get; }
        public uint Quantity { get; }
        public bool IsPacked { get; init; }

        public PackingItem(string name,uint quantity,bool isPacked=false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyPackingListItemName();

			}
            Name = name;
            Quantity = quantity;
            IsPacked = isPacked;
        }
    }
}
