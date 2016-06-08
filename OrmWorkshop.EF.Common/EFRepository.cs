#region licence

// <copyright file="EFRepository.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.EF.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	26.05.2016 18:19
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	27.05.2016 16:15
// </summary>

#endregion

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

using LinqSpecs;

namespace OrmWorkshop.EF.Common
{
	public class EFRepository : IEFRepository
	{
		private readonly IDbContext dbContext;

		public EFRepository(IDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void Save<T>(T entity) where T : class
		{
			this.GetSet<T>().AddOrUpdate(entity);
		}

		private IDbSet<T> GetSet<T>() where T : class
		{
			return this.dbContext.Set<T>();
		}

		public T GetById<T>(object id) where T : class
		{
			return this.GetSet<T>().Find(id);
		}

		public void Remove<T>(T entity) where T : class
		{
			this.GetSet<T>().Remove(entity);
		}

		public List<T> ListAll<T>() where T : class
		{
			return this.GetSet<T>().ToList();
		}

		public List<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return this.GetSet<T>().Where(expression).ToList();
		}

		public List<T> FindAll<T>(Specification<T> specification) where T : class
		{
			return this.FindAll(specification.IsSatisfiedBy());
		}

		public T FindFirst<T>(Specification<T> specification) where T : class
		{
			return this.GetSet<T>().FirstOrDefault();
		}

		public int QueryOverWithRowCount<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return this.GetSet<T>().Count(expression);
		}

		public void Flush()
		{
			throw new NotImplementedException();
		}
	}
}