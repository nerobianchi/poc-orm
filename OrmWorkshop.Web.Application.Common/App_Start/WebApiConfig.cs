using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;

using Castle.Windsor;

using OrmWorkshop.Web.Application.Common.WindsorRelated;

namespace OrmWorkshop.Web.Application.Common
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config, IWindsorContainer container, string applicationName)
		{
			MapRoutes(config, applicationName);
			RegisterControllerActivator(container);
		}

		private static void MapRoutes(HttpConfiguration config, string applicationName)
		{
			//config.MapHttpAttributeRoutes();
			config.MapHttpAttributeRoutes(new CentralizedPrefixProvider(string.Format("api/{0}/v{{version:int}}", applicationName)));

			config.Routes.MapHttpRoute(
				 name: "DefaultApi",
				 routeTemplate: "api/{controller}/{id}",
				 defaults: new { id = RouteParameter.Optional }
				 );
		}

		private static void RegisterControllerActivator(IWindsorContainer container)
		{
			HttpConfiguration config = GlobalConfiguration.Configuration;

			config.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
			config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
		}
	}
}