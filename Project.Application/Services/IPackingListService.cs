﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services
{
	public interface IPackingListReadService
	{
		Task<bool> ExistsByNameAsync(string name);
	}
}
