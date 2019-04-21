using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Core.Entities
{
	public class Order: Entity
	{
		//public string Name { get; set; }
		//public string Type { get; set; }
		//public DateTime Date { get; set; }
		//public string Gender { get; set; }
		//public bool IsActive { get; set; }

		public string Name { get; set; }

		public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

		public Order()
		{
		}
	}
}
