using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace OrmWorkshop.Web.Application.Common.WindsorRelated
{
	public class WindsorDependencyScope : IDependencyScope
	{
		private readonly IWindsorContainer container;

		private readonly IDisposable scope;

		public WindsorDependencyScope(IWindsorContainer container)
		{
			this.container = container;
			this.scope = container.BeginScope();
		}

		public object GetService(Type serviceType)
		{
			if (this.container.Kernel.HasComponent(serviceType))
			{
				return this.container.Resolve(serviceType);
			}
			else
			{
				return null;
			}
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.container.ResolveAll(serviceType).Cast<object>();
		}

		public void Dispose()
		{
			this.scope.Dispose();
		}
	}
}