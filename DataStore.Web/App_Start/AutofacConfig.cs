using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using DataStore.Application.Injection;

namespace DataStore.Web
{
	public class AutofacConfig
	{
		public static void ConfigureContainer(string connectionString = "DefaultConnection")
		{
			var builder = new ContainerBuilder();

			var config = GlobalConfiguration.Configuration;

			//Register your Web API controllers.  
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterModule(new AutofacDataModule(connectionString));

			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}