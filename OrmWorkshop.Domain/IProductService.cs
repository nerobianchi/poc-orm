using System.Collections.Generic;

namespace OrmWorkshop.Domain
{
	public interface IProductService
	{
		void AddNewProduct(Product product);

		void AddNewProducts(List<Product> productList);

		Product GetProduct(int productId);

		List<Product> ListAllProducts();

		void AddNewProductBoth(ProductDto product);

		void AddNewProductBothException(ProductDto productDto);
	}
}