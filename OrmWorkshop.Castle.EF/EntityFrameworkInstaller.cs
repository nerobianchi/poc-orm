using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace OrmWorkshop.Castle.EF
{
	public class EntityFrameworkInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<EntityFrameworkFacility>();
		}
	}
}