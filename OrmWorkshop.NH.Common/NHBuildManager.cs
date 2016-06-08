using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace OrmWorkshop.NH.Common
{
	public class NHBuildManager
	{
		public ISessionFactory BuildFluent(string mapAssemblyName, string commonMapAssemblyName, string connectionString, Type currentSessionContextType)
		{
			FluentConfiguration fluentConfiguration = Fluently
						.Configure()
						.Database(
									 MsSqlConfiguration
										 .MsSql2008
										 .IsolationLevel(IsolationLevel.ReadUncommitted)
										 .ConnectionString(connectionString)
										 .ShowSql()
						)
						.Mappings(mappingConfiguration =>
									 mappingConfiguration.FluentMappings
										 .AddFromAssembly(Assembly.Load(mapAssemblyName))
										 .AddFromAssembly(Assembly.Load(commonMapAssemblyName))
										 .Conventions.AddFromAssemblyOf<EnumConvention>()
						);

			//this.enversIntegration.IntegrateEnvers(fluentConfiguration);

			if (currentSessionContextType.GetInterfaces().Contains(typeof(ICurrentSessionContext)))
			{
				fluentConfiguration.ExposeConfiguration(cfg => cfg.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, currentSessionContextType.AssemblyQualifiedName));
			}
			else
			{
				throw new Exception("CurrentSessionContext is not set with the correct type");
			}

			return fluentConfiguration.BuildSessionFactory();
		}
	}
}