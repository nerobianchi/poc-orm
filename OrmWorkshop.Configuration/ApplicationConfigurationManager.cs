namespace OrmWorkshop.Configuration
{
	public class ApplicationConfigurationManager : IApplicationConfigurationManager
	{
		public ApplicationConfiguration ApplicationConfiguration
		{
			get
			{
				return new ApplicationConfiguration
						 {
							 DatabaseSetting = new DatabaseSetting
															{
																DefaultConnectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=orm_work_db;Integrated Security=True"
															}
						 };
			}
		}
	}
}