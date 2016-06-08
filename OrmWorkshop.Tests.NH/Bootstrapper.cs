using Castle.MicroKernel.Registration;
using Castle.Windsor;

using OrmWorkshop.Castle;
using OrmWorkshop.Castle.NH;
using OrmWorkshop.Configuration;
using OrmWorkshop.Domain;

namespace OrmWorkshop.Tests.NH
{
	public class Bootstrapper
	{
		private static IWindsorContainer CONTAINER;

		public static void Initialize()
		{
			CONTAINER = new WindsorContainer();

			//ServiceOverride dependency = Property.ForKey<IUnitOfWork>().Is("ThreadStaticUnitOfWorkNH");

			CONTAINER
				//.AddFacility<InterceptorFacility>()
				.Register(Component.For<IApplicationConfigurationManager>().ImplementedBy<ApplicationConfigurationManager>().LifestyleSingleton())
				.Register(Component.For<IProductService>().ImplementedBy<ProductService>().LifestyleTransient())

				.Register(Component.For<TransactionInterceptor>().LifestyleTransient())
				//.Register(Component.For<TransactionInterceptor>().DependsOn(dependency).LifestyleTransient())
				.Install(new NHInstaller())


				;
		}

		public static T Resolve<T>()
		{
			return CONTAINER.Resolve<T>();
		}
	}
}