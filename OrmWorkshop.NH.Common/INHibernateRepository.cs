using System;
using System.Linq;
using System.Linq.Expressions;

using LinqSpecs;

using NHibernate;

using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.NH.Common
{
	public interface INHibernateRepository : IRepository
	{
		ISession GetSession();

		IQueryable<T> GetQuery<T>(Expression<Func<T, bool>> expression);

		IQueryable<T> GetQuery<T>(Specification<T> specification);
	}
}