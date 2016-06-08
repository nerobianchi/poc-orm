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
using OrmWorkshop.Tests.Common;

using Xunit;

namespace OrmWorkshop.Tests.EF.Listing
{
	public class Tests
	{
		[Fact]
		public void given_a_product_when_listing_then_return_one_product(){
			DBOperation.CreateOneProduct();


			string name = "test_product_01";

			Bootstrapper.Initialize();
			IProductService service = Bootstrapper.Resolve<IProductService>();

			Product product = service.GetProduct(1);

			product.Should().NotBeNull();
			product.Name.Should().Be(name, "product name !!!");
			product.Id.Should().Be(1, "product id !!!");

			Bootstrapper.Dispose();
		}
		[Fact]
		public void given_two_products_when_listing_then_return_one_product_with_id_1()
		{
			DBOperation.CreateTwoProducts();

			string name = "test_product_01";
			int productId = 1;
			
			Bootstrapper.Initialize();
			IProductService service = Bootstrapper.Resolve<IProductService>();

			
			Product product = service.GetProduct(productId);

			product.Should().NotBeNull();
			product.Name.Should().Be(name, "product name !!!");
			product.Id.Should().Be(productId, "product id !!!");

			Bootstrapper.Dispose();
		}
		[Fact]
		public void given_two_products_when_listing_then_return_one_product_with_id_2()
		{
			DBOperation.CreateTwoProducts();

			string name = "test_product_02";
			int productId = 2;
			
			Bootstrapper.Initialize();
			IProductService service = Bootstrapper.Resolve<IProductService>();

			
			Product product = service.GetProduct(productId);

			product.Should().NotBeNull();
			product.Name.Should().Be(name, "product name !!!");
			product.Id.Should().Be(productId, "product id !!!");

			Bootstrapper.Dispose();
		}
	}
}