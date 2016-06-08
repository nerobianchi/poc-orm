using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using NHibernate;

using OrmWorkshop.Domain;
using OrmWorkshop.NH.Common;
using OrmWorkshop.Repositories.Common;
using OrmWorkshop.Repositories.NH;

namespace OrmWorkshop.Castle.NH
{
	public class NHInstaller : IWindsorInstaller
	{
		private const string AGENT_REPOSITORY = "AgentRepository";

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			ServiceOverride dependency = Property.ForKey<ISessionFactory>().Is("AgentSessionFactory");

			container
				.AddFacility<PersistenceFacility>()
				.Register
				(
					 Component
					 .For<IRepository>()
					 .ImplementedBy<NHibernateRepository>()
					 .Named(AGENT_REPOSITORY)
					 .DependsOn(dependency)
					 .LifestyleTransient()
				)
				.Register(Component.For<IProductRepository>().ImplementedBy<ProductRepository>().LifestyleTransient())
				.Register(Component.For<IInventoryRepository>().ImplementedBy<InventoryRepository>().LifestyleTransient())
				.Register(Component.For<IUnitOfWork>().ImplementedBy<SimpleUnitOfWork>().LifestylePerWebRequest());
		}
	}
}