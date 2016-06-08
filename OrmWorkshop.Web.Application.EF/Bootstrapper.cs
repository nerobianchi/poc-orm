using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OrmWorkshop.Castle;
using OrmWorkshop.Castle.EF;
using OrmWorkshop.Configuration;
using OrmWorkshop.Domain;
using OrmWorkshop.Web.Application.Common.WindsorRelated;
using System;

namespace OrmWorkshop.Web.Application.EF
{
	public class Bootstrapper
	{
		private static IWindsorContainer CONTAINER;

		public static IWindsorContainer Container
		{
			get { return CONTAINER; }
		}

		public static IWindsorContainer Initialize()
		{
			CONTAINER = new WindsorContainer();

			CONTAINER
				.Register(Component.For<IApplicationConfigurationManager>().ImplementedBy<ApplicationConfigurationManager>().LifestyleSingleton())
				.Register(Component.For<IProductService>().ImplementedBy<ProductService>().LifestyleTransient())
				.Install(new ApiControllersInstaller())

				.Register(Component.For<ExceptionHandlingInterceptor>().LifestyleTransient())

				.Install(new EntityFrameworkInstaller());

			return CONTAINER;
		}

		public static T Resolve<T>()
		{
			if (CONTAINER == null)
			{
				throw new Exception("Container is not initialized");
			}

			return CONTAINER.Resolve<T>();
		}

		public static void Dispose()
		{
			if (CONTAINER != null) CONTAINER.Dispose();
		}
	}
}