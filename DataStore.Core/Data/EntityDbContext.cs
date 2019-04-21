using System.Collections.Generic;
using System.Data.Entity;
using DataStore.Core.Entities;

namespace DataStore.Core.Data
{
	public class EntityDbContext: DbContext, IDbContext
	{
		public IDbSet<Order> Orders { get; set; }
		public IDbSet<OrderItem> OrderItems { get; set; }

		public EntityDbContext(string connectionstring) : base(connectionstring)
		{
			
		}

		public new IDbSet<T> Set<T>() where T : Entity
		{
			return base.Set<T>();
		}
	}
}