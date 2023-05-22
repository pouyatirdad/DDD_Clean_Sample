using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies.Temperature
{
	internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
	{
		public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
			=> new List<PackingItem>
			{
				new("Winter Hat",1),
				new("Scarf",1),
				new("Gloves",2),
				new("Hoodie",1),
				new("Warm Jacket",1)
			};

		public bool IsApplicable(PolicyData policyData)
		=> policyData.Temperature < 15;
	}
}
