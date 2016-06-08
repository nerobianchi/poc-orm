using System.Collections.Generic;

namespace OrmWorkshop.Domain
{
	public interface IProductRepository
	{
		void AddNewProduct(Product product);

		Product GetProduct(int productId);

		List<Product> ListAllProducts();
	}
}