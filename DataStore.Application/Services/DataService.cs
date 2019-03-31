using System.Collections.Generic;
using DataStore.Application.Extentions;
using DataStore.Core.Enums;

namespace DataStore.Application.Services
{
	public class DataService: IDataService
	{
		public ICollection<EnumOptionItem> GetOrderTypes()
		{
			return Enum<EnumOrderType>.ToOptionsList(true);
		}

		public ICollection<EnumOptionItem> GetGenderTypes()
		{
			return Enum<EnumGender>.ToOptionsList();
		}
	}
}