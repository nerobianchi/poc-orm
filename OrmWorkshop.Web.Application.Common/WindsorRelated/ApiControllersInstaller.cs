using System.Web.Http;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using OrmWorkshop.Castle;

namespace OrmWorkshop.Web.Application.Common.WindsorRelated
{
	public class ApiControllersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes
									.FromThisAssembly()
									.BasedOn<ApiController>()
									.LifestylePerWebRequest()
									.Configure(c => c.SelectInterceptorsWith(new ControllerInterceptorSelector()))
									.Configure(c => c.Interceptors<ExceptionHandlingInterceptor>())
									);
		}
	}
}