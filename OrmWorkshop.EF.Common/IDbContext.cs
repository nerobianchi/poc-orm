using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OrmWorkshop.EF.Common
{
	public interface IDbContext : IDisposable
	{
		Database Database { get; }

		DbEntityEntry Entry(object entity);

		IDbSet<TEntity> Set<TEntity>() where TEntity : class;

		int SaveChanges();
	}
}