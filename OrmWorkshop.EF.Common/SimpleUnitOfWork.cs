#region licence

// <copyright file="SimpleUnitOfWork.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.EF.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	27.05.2016 10:54
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	27.05.2016 14:39
// </summary>

#endregion

using System.Data;
using System.Data.Entity;

using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.EF.Common
{
	public class SimpleUnitOfWork : IUnitOfWork
	{
		private readonly IDbContext dbContext;

		public SimpleUnitOfWork(IDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void PreProceed(string methodName)
		{
			Database database = this.dbContext.Database;

			if (this.Guard(methodName))
			{
				database.BeginTransaction(IsolationLevel.ReadUncommitted);
			}
		}

		private const string SAVE = "Save";

		private const string REMOVE = "Remove";

		private const string SAVE_OR_UPDATE = "SaveOrUpdate";

		private const string UPDATE = "Update";

		private bool Guard(string methodName)
		{
			return true;

			//return methodName == SAVE
			//		|| methodName == REMOVE
			//		|| methodName == SAVE_OR_UPDATE
			//		|| methodName == UPDATE;
		}

		public void PostProceed(string methodName)
		{
			Database database = this.dbContext.Database;
			if (this.Guard(methodName))
			{
				try
				{
					if (database.CurrentTransaction != null)
					{
						this.dbContext.SaveChanges();
						database.CurrentTransaction.Commit();
					}
				}
				catch
				{
					if (database.CurrentTransaction != null)
					{
						database.CurrentTransaction.Rollback();
					}
				}
				finally
				{
					this.dbContext.Dispose();
				}
			}
		}

		public void Rollback()
		{
			Database database = this.dbContext.Database;
			if (database.CurrentTransaction != null)
			{
				database.CurrentTransaction.Rollback();
			}
		}
	}
}