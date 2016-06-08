using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;

using Castle.Windsor;

using OrmWorkshop.Web.Application.Common;
using OrmWorkshop.Web.Application.Common.WindsorRelated;

namespace OrmWorkshop.Web.Application.Asd
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config, IWindsorContainer container)
		{
			MapRoutes(config);
			RegisterControllerActivator(container);
		}

		private static void MapRoutes(HttpConfiguration config)
		{
			//config.MapHttpAttributeRoutes();
			config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api/nh/v{version:int}"));

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