using OrmWorkshop.Domain;
using OrmWorkshop.NH.Common;

namespace OrmWorkshop.Repositories.NH
{
	public class InventoryMap : EntityMap<Inventory>
	{
		public InventoryMap()
		{
			this.Table("tblInventory");

			this.Id(m => m.Id);
			this.Map(m => m.Name).CustomSqlType("varchar(50)").Nullable();
		}
	}
}