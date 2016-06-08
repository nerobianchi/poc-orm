using System;

using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

using NHibernate;

using OrmWorkshop.NH.Common;

namespace OrmWorkshop.Castle.NH
{
	public abstract class AbstractPersistenceFacility : AbstractFacility
	{
		//private EnversIntegration enversIntegration;

		protected abstract string SessionFactoryName { get; }

		protected abstract string DomainAssemblyName { get; }

		protected override void Init()
		{
			//this.enversIntegration = new EnversIntegration(base.Kernel);

			//this.enversIntegration.Register<IAuditableEntity>(this.DomainAssemblyName);
			this.Kernel.Register
				(
				 Component
					 .For<ISessionFactory>()
					 .Named(this.SessionFactoryName)
					 .UsingFactoryMethod(this.BuildFluent)
					 .LifestyleSingleton()
				);
		}

		private ISessionFactory BuildFluent()
		{
			return new NHBuildManager().BuildFluent(this.MapAssemblyName, this.CommonMapAssemblyName, this.ConnectionString, this.CurrentSessionContextType);
		}

		protected abstract string MapAssemblyName { get; }

		protected abstract string CommonMapAssemblyName { get; }

		protected abstract string ConnectionString { get; }

		protected abstract Type CurrentSessionContextType { get; }
	}
}