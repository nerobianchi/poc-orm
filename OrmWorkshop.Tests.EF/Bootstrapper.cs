using System;

using Castle.MicroKernel.Registration;
using Castle.Windsor;

using OrmWorkshop.Castle.EF;
using OrmWorkshop.Configuration;
using OrmWorkshop.Domain;

namespace OrmWorkshop.Tests.EF
{
	public class Bootstrapper
	{
		private static IWindsorContainer CONTAINER;

		public static void Initialize()
		{
			CONTAINER = new WindsorContainer();

			CONTAINER
				//.AddFacility<InterceptorFacility>()
				.Register(Component.For<IApplicationConfigurationManager>().ImplementedBy<ApplicationConfigurationManager>().LifestyleSingleton())
				.Register(Component.For<IProductService>().ImplementedBy<ProductService>().LifestyleTransient())

				//.Register(Component.For<TransactionInterceptor>().LifestyleTransient())

				.Install(new EntityFrameworkInstaller())
				;
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