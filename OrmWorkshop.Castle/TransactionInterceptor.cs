#region licence

// <copyright file="Bootstrapper.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop
// 	Created By: 	erdem.ozdemir
// 	Create Date:	25.05.2016 17:51
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	25.05.2016 17:51
// </summary>

#endregion licence

using Castle.DynamicProxy;

using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.Castle
{
	public class TransactionInterceptor : StandardInterceptor
	{
		protected readonly IUnitOfWork unitOfWork;

		public TransactionInterceptor(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override void PreProceed(IInvocation invocation)
		{
			this.unitOfWork.PreProceed(invocation.Method.Name);
		}

		protected override void PostProceed(IInvocation invocation)
		{
			this.unitOfWork.PostProceed(invocation.Method.Name);
		}
	}
}