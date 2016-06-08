using System;
using System.Collections.Generic;

namespace OrmWorkshop.Domain
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository productRepository;

		private readonly IInventoryRepository inventoryRepository;

		public ProductService(IProductRepository productRepository, IInventoryRepository inventoryRepository)
		{
			this.productRepository = productRepository;
			this.inventoryRepository = inventoryRepository;
		}

		public void AddNewProduct(Product product)
		{
			this.productRepository.AddNewProduct(product);
		}
		public void AddNewProductBoth(ProductDto productDto)
		{
			Product product = new Product() { Name = productDto.Name };
			Inventory inventory = new Inventory() { Name = productDto.Name };

			this.productRepository.AddNewProduct(product);
			this.inventoryRepository.AddNewInventory(inventory);
		}

		public void AddNewProductBothException(ProductDto productDto)
		{
			Product product = new Product() { Name = productDto.Name };
			Inventory inventory = new Inventory() { Name = productDto.Name };

			this.productRepository.AddNewProduct(product);
			this.inventoryRepository.AddNewInventory(inventory);

			throw new Exception("simple exception");
		}

		public void AddNewProducts(List<Product> productList)
		{
			foreach (Product product in productList)
			{
				this.productRepository.AddNewProduct(product);
			}
		}

		public Product GetProduct(int productId)
		{
			return this.productRepository.GetProduct(productId);
		}

		public List<Product> ListAllProducts()
		{
			return this.productRepository.ListAllProducts();
		}
	}
}