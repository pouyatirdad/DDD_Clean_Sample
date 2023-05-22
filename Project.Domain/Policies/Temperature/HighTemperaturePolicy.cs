using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies.Temperature
{
	internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
	{
		public IEnumerable<PackingItem> GenerateItems(PolicyData policyData) 
			=>new List<PackingItem>
			{
				new("Hat",1),
				new("SunGlass",1),
				new("Cream",2)
			} ;

		public bool IsApplicable(PolicyData policyData)
		=> policyData.Temperature > 25;
	}
}
