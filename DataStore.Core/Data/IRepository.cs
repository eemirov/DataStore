using System.Linq;
using DataStore.Core.Entities;

namespace DataStore.Core.Data
{
	public interface IRepository<T> where T:Entity
	{
		T GetById(int id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
		IQueryable<T> GetAll();
	}
}