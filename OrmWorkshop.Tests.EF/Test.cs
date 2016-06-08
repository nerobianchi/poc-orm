#region licence

// <copyright file="Test.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop
// 	Created By: 	erdem.ozdemir
// 	Create Date:	25.05.2016 16:23
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	25.05.2016 16:23
// </summary>

#endregion licence

using FluentAssertions;
using OrmWorkshop.Domain;
using System;
using System.Collections.Generic;

using OrmWorkshop.Tests.Common;

using Xunit;

namespace OrmWorkshop.Tests.EF
{
	public class Test : IDisposable
	{
		public Test()
		{
			DBOperation.Cleanup();

			Bootstrapper.Initialize();
		}


		public void Dispose()
		{
			Bootstrapper.Dispose();
		}

		//[Fact]
		//public void given_a_product_when_persisting_then_successfully_persisted_all()
		//{
		//	given_a_product_when_persisting_then_successfully_persisted();
		//	given_two_products_when_persisting_then_successfully_persisted();
		//}
		[Fact]
		public void given_a_product_when_persisting_then_successfully_persisted()
		{
			Product product = new Product();
			string name = "test_product_01";
			product.Name = name;

			IProductService service = Bootstrapper.Resolve<IProductService>();
			service.AddNewProduct(product);

			List<Product> item = DBOperation.ReadAllProducts();

			item.Count.Should().Be(1, "item count !!!");
			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");
		}

		[Fact]
		public void given_two_products_when_persisting_then_successfully_persisted()
		{
			Product product = new Product();
			string name = "test_product_01";
			product.Name = name;

			Product product2 = new Product();
			string name2 = "test_product_02";
			product2.Name = name2;

			IProductService service = Bootstrapper.Resolve<IProductService>();
			service.AddNewProduct(product);
			service.AddNewProduct(product2);

			List<Product> item = DBOperation.ReadAllProducts();

			item.Count.Should().Be(2, "item count !!!");

			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");

			item[1].Name.Should().Be(name2, "product name !!!");
			item[1].Id.Should().Be(2, "product id !!!");
		}

		[Fact]
		public void given_two_products_when_persisting_at_once_then_successfully_persisted()
		{
			Product product = new Product();
			string name = "test_product_01";
			product.Name = name;

			Product product2 = new Product();
			string name2 = "test_product_02";
			product2.Name = name2;

			IProductService service = Bootstrapper.Resolve<IProductService>();

			service.AddNewProducts(new List<Product> { product, product2 });

			List<Product> item = DBOperation.ReadAllProducts();

			item.Count.Should().Be(2, "item count !!!");

			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");

			item[1].Name.Should().Be(name2, "product name !!!");
			item[1].Id.Should().Be(2, "product id !!!");
		}
	}
}