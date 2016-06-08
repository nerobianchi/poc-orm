using OrmWorkshop.Web.Application.Common;
using OrmWorkshop.Web.Application.Common.WindsorRelated;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OrmWorkshop.Web.Application.Asd
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			ConfigureWindsor(GlobalConfiguration.Configuration);

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(c => WebApiConfig.Register(c, Bootstrapper.Container));
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		}

		public static void ConfigureWindsor(HttpConfiguration configuration)
		{
			Bootstrapper.Initialize();

			SetDependencyResolver(configuration);
		}

		private static void SetDependencyResolver(HttpConfiguration configuration)
		{
			var dependencyResolver = new WindsorDependencyResolver(Bootstrapper.Container);
			configuration.DependencyResolver = dependencyResolver;
		}

		protected void Application_End()
		{
			Bootstrapper.Container.Dispose();
			base.Dispose();
		}
	}
}