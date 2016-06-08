namespace OrmWorkshop.Configuration
{
	public class ApplicationConfiguration
	{
		public virtual string ApplicationName { get; set; }

		public virtual string Environment { get; set; }

		public virtual DatabaseSetting DatabaseSetting { get; set; }
	}
}