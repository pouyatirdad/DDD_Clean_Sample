using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies.Universal
{
	internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
	{
		private const int MaximumQuantity = 7;
		public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
			=> new List<PackingItem>
			{
				new("Pants",MaximumQuantity),
				new("Socks",MaximumQuantity),
				new("TShirt",MaximumQuantity),
				new("Shampoo",2),
				new("Thoothbrush",1),
				new("Towel",1),
				new("Passport",1),
				new("Thoothpaste",1)
			};

		public bool IsApplicable(PolicyData policyData)
		=> true;
	}
}
