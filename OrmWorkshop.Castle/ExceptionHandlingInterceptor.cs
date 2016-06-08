using Castle.DynamicProxy;
using OrmWorkshop.Repositories.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrmWorkshop.Castle
{
	public class ExceptionHandlingInterceptor : TransactionInterceptor
	{
		public ExceptionHandlingInterceptor(IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}

		protected override void PerformProceed(IInvocation invocation)
		{
			base.PerformProceed(invocation);
			Task<HttpResponseMessage> task = invocation.ReturnValue as Task<HttpResponseMessage>;
			if (task != null && task.Exception != null)
			{
				this.unitOfWork.Rollback();
			}
		}
	}
}