using Project.Infrastructure.Ef.Models;
using Project.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Queries
{
	internal static class Extensions
	{
		public static PackingListDTO AsDTO(this PackingListReadModel readModel) => new()
		{
			Id = readModel.Id,
			Name = readModel.Name,
			Localization=new LocalizationDto
			{
				City=readModel.Localization?.City,
				Country=readModel.Localization?.Country,
			},
			items=readModel.items?.Select(x=>new PackingItemDTO
			{
				IsPacked=x.IsPacked,
				Name=x.Name,
				Quantity=x.Quantity
			})
		};
	}
}
