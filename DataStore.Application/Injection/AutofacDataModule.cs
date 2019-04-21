using System.Reflection;
using Autofac;
using DataStore.Core.Data;
using Module = Autofac.Module;

namespace DataStore.Application.Injection
{
	public class AutofacDataModule : Module
	{
		private readonly string _connectionString;

		public AutofacDataModule(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register<IDbContext>(c => new EntityDbContext(_connectionString));
			builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

			var dataAccess = Assembly.GetExecutingAssembly();
			//registers all services
			builder.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

			base.Load(builder);
		}
	}
}
