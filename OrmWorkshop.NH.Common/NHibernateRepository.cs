using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using LinqSpecs;

using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace OrmWorkshop.NH.Common
{
	public class NHibernateRepository : INHibernateRepository
	{
		protected ISessionFactory iSessionFactory;

		public NHibernateRepository(ISessionFactory iSessionFactory)
		{
			this.iSessionFactory = iSessionFactory;
		}

		public ISession GetSession()
		{
			return this.iSessionFactory.GetCurrentSession();
		}

		public T GetById<T>(object id) where T : class
		{
			return this.GetSession().Get<T>(id);
		}

		public int QueryOverWithRowCount<T>(Expression<Func<T, bool>> expression) where T : class
		{
			ISession session = this.GetSession();

			int returnValue = session.QueryOver<T>().Where(expression).Select(Projections.RowCount()).FutureValue<int>().Value;

			return returnValue;
		}

		public List<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return this.GetQuery(expression).ToList();
		}

		public List<T> FindAll<T>(Specification<T> specification) where T : class
		{
			return this.FindAll(specification.IsSatisfiedBy());
		}

		public T FindFirst<T>(Specification<T> specification) where T : class
		{
			return this.GetQuery(specification).FirstOrDefault();
		}

		public IQueryable<T> GetQuery<T>(Expression<Func<T, bool>> expression)
		{
			ISession session = this.GetSession();

			return Queryable.Where(session.Query<T>(), expression);
		}

		public IQueryable<T> GetQuery<T>(Specification<T> specification)
		{
			return this.GetQuery(specification.IsSatisfiedBy());
		}

		public List<T> ListAll<T>() where T : class
		{
			ISession session = this.GetSession();

			return session.QueryOver<T>().List<T>() as List<T>;
		}

		public void Save<T>(T domainObject) where T : class
		{
			ISession session = this.GetSession();

			session.SaveOrUpdate(domainObject);
		}

		public void Remove<T>(T domainObject) where T : class
		{
			ISession session = this.GetSession();

			session.Delete(domainObject);
		}

		public void Flush()
		{
			this.GetSession().Flush();
		}
	}
}