using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.Castle.EF
{
	class ConnectionStringProvider : IConnectionStringProvider
	{
		public string ConnectionString { get; set; }
	}
}