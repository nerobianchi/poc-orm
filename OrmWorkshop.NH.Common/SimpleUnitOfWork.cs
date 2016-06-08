#region licence
// <copyright file="SimpleUnitOfWork.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.NH.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	26.05.2016 15:23
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	26.05.2016 15:23
// </summary>
#endregion

using System.Data;

using NHibernate;
using NHibernate.Context;

using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.NH.Common
{
	public class SimpleUnitOfWork : IUnitOfWork
	{
		private readonly ISessionFactory sessionFactory;

		public SimpleUnitOfWork(ISessionFactory sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}

		public void PreProceed(string methodName)
		{
			ISession session = this.sessionFactory.OpenSession();
			
			if (session == null) return;
			
			if (this.Guard(methodName))
			{
				session.BeginTransaction(IsolationLevel.ReadUncommitted);
			}

			CurrentSessionContext.Bind(session);
		}

		private const string SAVE = "Save";
		private const string REMOVE = "Remove";
		private const string SAVE_OR_UPDATE = "SaveOrUpdate";
		private const string UPDATE = "Update";

		private bool Guard(string methodName)
		{
			return true;

			return methodName == SAVE
					 || methodName == REMOVE
					 || methodName == SAVE_OR_UPDATE
					 || methodName == UPDATE;
		}

		public void PostProceed(string methodName)
		{
			ISession session = CurrentSessionContext.Unbind(this.sessionFactory);
			if (session == null) return;
			
			if (this.Guard(methodName))
			{
				if (session.Transaction.IsActive)
				{
					session.Transaction.Commit();
				}
			}
			session.Dispose();
		}

		public void Rollback()
		{
			ISession session = CurrentSessionContext.Unbind(this.sessionFactory);
			if (session == null) return;
			
			if (session.Transaction.IsActive)
			{
				session.Transaction.Rollback();
			}

			session.Dispose();
		}
	}
}