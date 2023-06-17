using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies.Gender
{
	internal class FeMaleGenderPolicy : IPackingItemsPolicy
	{
		public IEnumerable<PackingItem> GenerateItems(PolicyData policyData) => new List<PackingItem>()
		{
		new ("Lipstick",1),
		new ("Powder",1),
		new ("Eyeliner",1),
		};

		public bool IsApplicable(PolicyData policyData) => policyData.Gender is Consts.Gender.Female;
	}
}
