using System.Data.Entity;
using DataStore.Core.Entities;

namespace DataStore.Core.Data
{
	public interface IDbContext
	{
		IDbSet<T> Set<T>() where T : Entity;
		int SaveChanges();
	}
}