using System.Web.Mvc;

namespace OrmWorkshop.Web.Application.Asd
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
