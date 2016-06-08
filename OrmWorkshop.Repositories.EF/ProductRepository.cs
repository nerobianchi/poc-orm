using OrmWorkshop.Domain;
using OrmWorkshop.Repositories.Common;
using System.Collections.Generic;

namespace OrmWorkshop.Repositories.EF
{
	//public class ProductRepository : IProductRepository
	//{
	//	private readonly IDbContext dbContext;
	//	private readonly IRepository repository;

	//	public ProductRepository(IDbContext dbContext)
	//	{
	//		this.dbContext = dbContext;
	//	}

	//	public void AddNewProduct(Product product)
	//	{
	//		this.dbContext.Set<Product>().AddOrUpdate(product);
	//	}

	//	public Product GetProduct(int productId)
	//	{
	//		return this.dbContext.Set<Product>().Find(productId);
	//	}

	//	public List<Product> ListAllProducts()
	//	{
	//		throw new System.NotImplementedException();
	//	}
	//}

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
			return this.repository.GetById<Product>(productId);
		}

		public List<Product> ListAllProducts()
		{
			return this.repository.ListAll<Product>();
		}
	}
}