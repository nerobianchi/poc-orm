using FluentNHibernate.Mapping;

using OrmWorkshop.Domain;

namespace OrmWorkshop.NH.Common
{
	public abstract class EntityMap<T> : ClassMap<T> where T : Entity
	{
		protected EntityMap()
		{
			base.Id(x => x.Id).GeneratedBy.Native().Not.Nullable();
		}
	}
}