using System.Data.Entity;
using System.Reflection;

using OrmWorkshop.EF.Common;
using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.Repositories.EF
{
	public class OrmWorkshopContext : DbContext, IDbContext
	{
		public OrmWorkshopContext(IConnectionStringProvider connectionStringProvider)
		{
			this.Database.Connection.ConnectionString = connectionStringProvider.ConnectionString;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			string mapAssemblyName = "OrmWorkshop.Repositories.EF";
			
			modelBuilder.Configurations.AddFromAssembly(Assembly.Load(mapAssemblyName));

			base.OnModelCreating(modelBuilder);
		}

		public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
		{
			return base.Set<TEntity>();
		}

	}
}