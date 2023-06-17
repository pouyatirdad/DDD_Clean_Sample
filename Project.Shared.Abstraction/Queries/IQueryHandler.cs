﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Abstraction.Queries
{
	public interface IQueryHandler<TQuery,TResult> where TQuery : class,IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query);
	}
}
