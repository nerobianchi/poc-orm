using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

using OrmWorkshop.Configuration;
using OrmWorkshop.Domain;
using OrmWorkshop.EF.Common;
using OrmWorkshop.Repositories.Common;
using OrmWorkshop.Repositories.EF;

namespace OrmWorkshop.Castle.EF
{
	public class EntityFrameworkFacility : AbstractFacility
	{
		private IConnectionStringProvider GetConnectionStringProvider()
		{
			var applicationConfiguration = this.Kernel.Resolve<IApplicationConfigurationManager>().ApplicationConfiguration;
			return new ConnectionStringProvider()
					 {
						 ConnectionString = applicationConfiguration.DatabaseSetting.DefaultConnectionString
					 };

		}
		private const string AGENT_REPOSITORY = "AgentRepository";

		protected override void Init()
		{
			Kernel
					.Register(Component.For<IDbContext>().ImplementedBy<OrmWorkshopContext>().LifestylePerWebRequest())

					.Register(Component.For<IRepository>().ImplementedBy<EFRepository>().Named(AGENT_REPOSITORY).LifestyleTransient())
					.Register(Component.For<IProductRepository>().ImplementedBy<ProductRepository>().LifestyleTransient())
					.Register(Component.For<IInventoryRepository>().ImplementedBy<InventoryRepository>().LifestyleTransient())
					.Register(Component.For<IConnectionStringProvider>().UsingFactoryMethod(this.GetConnectionStringProvider).LifestyleSingleton())

					.Register(Component.For<IUnitOfWork>().ImplementedBy<SimpleUnitOfWork>().LifestylePerWebRequest());
		}
	}
}
