using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Core.Entities
{
	public class OrderItem: Entity
	{
		public int OrderId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string ValueType { get; set; }
	}
}
