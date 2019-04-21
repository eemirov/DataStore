using System.Collections.Generic;
using DataStore.Application.Extentions;
using DataStore.Application.Model;

namespace DataStore.Application.Services
{
	public interface IOrderDataService: IApplicationService
	{
		ICollection<EnumOptionItem> GetOrderTypes();

		ICollection<EnumOptionItem> GetGenderTypes();

		void AddOrInsertOrder(IOrderModel item);

		void DeleteOrder(int id);

		ICollection<IOrderModel> OrderList(string filter);
	}
}