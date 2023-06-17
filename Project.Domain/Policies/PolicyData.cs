using Project.Domain.Consts;
using Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Policies
{
	public record PolicyData(TravelDays Days,Consts.Gender Gender,ValueObjects.Temperature Temperature,Localization Localization);
}
