using System.Data.Entity.ModelConfiguration;

using OrmWorkshop.Domain;

namespace OrmWorkshop.Repositories.EF
{
	public class ProductMap : EntityTypeConfiguration<Product>
	{
		public ProductMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);

			// Table and relationships 
			this.ToTable("tblProduct");
			//HasRequired(o => o.Buyer);
		}
	}
}