using System;
using System.Reflection;

using Castle.DynamicProxy;

namespace OrmWorkshop.Web.Application.Common.WindsorRelated
{
	public class ControllerInterceptorSelector : IInterceptorSelector
	{
		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			if (method.Name == "ExecuteAsync")
			{
				return interceptors;
			}
			else
			{
				return new IInterceptor[] { };
			}
		}
	}
}