#region licence
// <copyright file="OrdersController.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.Web.Application.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	02.06.2016 15:59
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	02.06.2016 16:00
// </summary>
#endregion

using System.Collections.Generic;
using System.Web.Http;

namespace OrmWorkshop.Web.Application.Common.Controllers
{
	public class OrdersController : ApiController
	{
		[HttpGet]
		public List<string> List()
		{
			return new List<string>() { "test_01" };
		}
	}
}