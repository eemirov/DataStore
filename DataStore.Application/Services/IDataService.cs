using System.Collections.Generic;
using DataStore.Application.Extentions;

namespace DataStore.Application.Services
{
	public interface IDataService: IApplicationService
	{
		ICollection<EnumOptionItem> GetOrderTypes();

		ICollection<EnumOptionItem> GetGenderTypes();
	}
}