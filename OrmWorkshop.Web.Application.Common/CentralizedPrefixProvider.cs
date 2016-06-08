using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace OrmWorkshop.Web.Application.Common
{
	public class CentralizedPrefixProvider : DefaultDirectRouteProvider
	{
		private readonly string centralizedPrefix;

		public CentralizedPrefixProvider(string centralizedPrefix)
		{
			this.centralizedPrefix = centralizedPrefix;
		}

		protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
		{
			var existingPrefix = base.GetRoutePrefix(controllerDescriptor);
			if (existingPrefix == null) return this.centralizedPrefix;

			return string.Format("{0}/{1}", this.centralizedPrefix, existingPrefix);
		}
	}
}