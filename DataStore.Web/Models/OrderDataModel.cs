using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataStore.Application.Extentions;

namespace DataStore.Web.Models
{
	public class OrderDataModel
	{
		public ICollection<EnumOptionItem> OrderTypes { get; set; }
		public ICollection<EnumOptionItem> GenderTypes { get; set; }

		public OrderDataModel()
		{
			OrderTypes = new List<EnumOptionItem>();
			GenderTypes = new List<EnumOptionItem>();
		}
	}
}