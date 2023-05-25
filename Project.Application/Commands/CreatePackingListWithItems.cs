using Project.Domain.Consts;
using Project.Shared.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Commands
{
	public record CreatePackingListWithItems(Guid Id,string Name,ushort Days,Gender Gender,
		LocalizationWriteModel Localization):ICommand;

	public record LocalizationWriteModel(string City,string Country);
}
