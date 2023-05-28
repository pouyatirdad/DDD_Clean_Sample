﻿using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTO
{
	internal class PackingListDTO
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Localization Localization { get; set; }
        public IEnumerable<PackingItemDTO> items { get; set; }
    }
}
