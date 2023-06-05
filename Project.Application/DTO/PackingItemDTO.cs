using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTO
{
	public class PackingItemDTO
	{
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public bool IsPacked { get; set; }
    }
}
