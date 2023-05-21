using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies.Gender
{
	internal class MaleGenderPolicy : IPackingItemsPolicy
	{
		public IEnumerable<PackingItem> GenerateItems(PolicyData policyData) => new List<PackingItem>()
		{
		new ("Laptop",1),
		new ("Beer",3),
		new ("Book",1),
		};

		public bool IsApplicable(PolicyData policyData) => policyData.Gender is Consts.Gender.Male;
	}
}
