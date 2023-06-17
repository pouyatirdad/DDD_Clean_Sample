using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies
{
	public interface IPackingItemsPolicy
	{
		bool IsApplicable(PolicyData policyData);
		IEnumerable<PackingItem> GenerateItems(PolicyData policyData);
	}
}
