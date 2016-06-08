namespace OrmWorkshop.Repositories.Common
{
	public interface IUnitOfWork
	{
		void PreProceed(string methodName);

		void PostProceed(string methodName);

		void Rollback();
	}
}