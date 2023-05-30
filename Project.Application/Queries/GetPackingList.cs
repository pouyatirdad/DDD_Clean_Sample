using Project.Application.DTO;
using Project.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Queries
{
	public class GetPackingList:IQuery<PackingListDTO>
	{
		public Guid Id { get; set; }
	}
}
