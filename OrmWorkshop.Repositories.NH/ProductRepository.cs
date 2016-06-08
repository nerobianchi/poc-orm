#region licence

// <copyright file="ProductRepository.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.Repositories.NH
// 	Created By: 	erdem.ozdemir
// 	Create Date:	26.05.2016 16:02
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	26.05.2016 16:02
// </summary>

#endregion licence

using OrmWorkshop.Domain;
using OrmWorkshop.Repositories.Common;
using System.Collections.Generic;

namespace OrmWorkshop.Repositories.NH
{
	public class ProductRepository : IProductRepository
	{
		private readonly IRepository repository;

		public ProductRepository(IRepository repository)
		{
			this.repository = repository;
		}

		public void AddNewProduct(Product product)
		{
			this.repository.Save(product);
		}

		public Product GetProduct(int productId)
		{
			throw new System.NotImplementedException();
		}

		public List<Product> ListAllProducts()
		{
			return this.repository.ListAll<Product>();
		}
	}
}