using System;

using NHibernate.Context;

using OrmWorkshop.Configuration;

namespace OrmWorkshop.Castle.NH
{
	public class PersistenceFacility : AbstractPersistenceFacility
	{
		private ApplicationConfiguration applicationConfiguration;

		protected override void Init()
		{
			this.applicationConfiguration = this.Kernel.Resolve<IApplicationConfigurationManager>().ApplicationConfiguration;

			base.Init();
		}

		private const string SESSION_FACTORY_NAME = "AgentSessionFactory";

		protected override string SessionFactoryName
		{
			get { return SESSION_FACTORY_NAME; }
		}

		private const string DOMAIN_ASSEMBLY_NAME = "OrmWorkshop.Domain";

		protected override string DomainAssemblyName
		{
			get { return string.Format(DOMAIN_ASSEMBLY_NAME, (object)this.applicationConfiguration.ApplicationName); }
		}

		private const string MAP_ASSEMBLY_NAME = "OrmWorkshop.Repositories.NH";

		protected override string MapAssemblyName
		{
			get { return string.Format(MAP_ASSEMBLY_NAME, (object)this.applicationConfiguration.ApplicationName); }
		}

		private static readonly string COMMON_MAP_ASSEMBLY_NAME = "OrmWorkshop.Repositories.Common";

		protected override string CommonMapAssemblyName
		{
			get { return COMMON_MAP_ASSEMBLY_NAME; }
		}

		protected override string ConnectionString
		{
			get { return this.applicationConfiguration.DatabaseSetting.DefaultConnectionString; }
		}

		protected override Type CurrentSessionContextType
		{
			get { return typeof(WebSessionContext); }
			//get { return typeof(ThreadStaticSessionContext); }
		}
	}
}