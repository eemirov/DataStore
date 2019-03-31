using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace DataStore.Application.Injection
{
	public class AutofacDataModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//builder.Register<IDbContext>(c => new ScorecardEntities());
			//builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
			//builder.RegisterType<SQLRepository>().As<ISQLRepository>();
			//builder.RegisterType<MemoryCacheStorage>().As<ICacheStorage>();

			var dataAccess = Assembly.GetExecutingAssembly();
			//registers all services
			builder.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

			base.Load(builder);
		}
	}
}
