using System.Data.Entity.ModelConfiguration;

using OrmWorkshop.Domain;

namespace OrmWorkshop.Repositories.EF
{
	public class InventoryMap : EntityTypeConfiguration<Inventory>
	{
		public InventoryMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);

			// Table and relationships 
			this.ToTable("tblInventory");
			//HasRequired(o => o.Buyer);
		}
	}
}