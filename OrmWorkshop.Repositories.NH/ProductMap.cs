#region licence

// <copyright file="IProductService.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop
// 	Created By: 	erdem.ozdemir
// 	Create Date:	25.05.2016 16:27
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	25.05.2016 16:28
// </summary>

#endregion licence

using OrmWorkshop.Domain;
using OrmWorkshop.NH.Common;

namespace OrmWorkshop.Repositories.NH
{
	public class ProductMap : EntityMap<Product>
	{
		public ProductMap()
		{
			this.Table("tblProduct");

			this.Id(m => m.Id);
			this.Map(m => m.Name).CustomSqlType("varchar(50)").Nullable();
		}
	}
}