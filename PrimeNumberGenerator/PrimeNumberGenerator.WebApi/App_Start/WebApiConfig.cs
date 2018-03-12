using System.Web.Http;

namespace PrimeNumberGenerator.WebApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "PrimeNumberGeneratorWebApi",
				routeTemplate: "api/{controller}/{number}"
			);
		}
	}
}
