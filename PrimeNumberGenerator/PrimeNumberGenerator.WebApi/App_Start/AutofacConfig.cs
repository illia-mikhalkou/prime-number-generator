using Autofac;
using Autofac.Integration.WebApi;
using PrimeNumberGenerator.WebApi.Interfaces;
using PrimeNumberGenerator.WebApi.Services.PrimeNumber;
using System.Reflection;
using System.Web.Http;

namespace PrimeNumberGenerator.WebApi.App_Start
{
	public class AutofacConfig
	{
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<PrimeNumberService>().As<IPrimeNumberService>().SingleInstance();

			var container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}