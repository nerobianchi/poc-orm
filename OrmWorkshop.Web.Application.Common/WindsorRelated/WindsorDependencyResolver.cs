#region licence

// <copyright file="WindsorDependencyResolver.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.Web.Application
// 	Created By: 	erdem.ozdemir
// 	Create Date:	01.06.2016 11:25
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	01.06.2016 11:25
// </summary>

#endregion licence

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

using Castle.Windsor;

namespace OrmWorkshop.Web.Application.Common.WindsorRelated
{
	public class WindsorDependencyResolver : IDependencyResolver
	{
		private readonly IWindsorContainer container;

		public WindsorDependencyResolver(IWindsorContainer container)
		{
			this.container = container;
		}

		public IDependencyScope BeginScope()
		{
			return new WindsorDependencyScope(this.container);
		}

		public object GetService(Type serviceType)
		{
			return this.container.Kernel.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			if (!this.container.Kernel.HasComponent(serviceType))
			{
				return new object[0];
			}

			return this.container.ResolveAll(serviceType).Cast<object>();
		}

		public void Dispose()
		{
			this.container.Dispose();
		}
	}
}