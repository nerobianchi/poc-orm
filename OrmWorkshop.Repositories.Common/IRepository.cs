#region licence

// <copyright file="IRepository.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.Repositories.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	26.05.2016 14:48
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	27.05.2016 16:14
// </summary>

#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using LinqSpecs;

namespace OrmWorkshop.Repositories.Common
{
	public interface IRepository
	{
		void Save<T>(T entity) where T : class;

		T GetById<T>(object id) where T : class;

		void Remove<T>(T entity) where T : class;

		List<T> ListAll<T>() where T : class;

		List<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class;

		List<T> FindAll<T>(Specification<T> specification) where T : class;

		T FindFirst<T>(Specification<T> specification) where T : class;

		int QueryOverWithRowCount<T>(Expression<Func<T, bool>> expression) where T : class;

		void Flush();
	}
}