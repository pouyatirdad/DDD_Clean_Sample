using Project.Domain.Entities;
using Project.Domain.ValueObjects;
using Project.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Events
{
	public record PackingItemAdded(PackingList PackingList,PackingItem PackingItem):IDomainEvent;
}
