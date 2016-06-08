using FluentAssertions;
using OrmWorkshop.Domain;
using OrmWorkshop.Tests.Common;

using RestSharp;
using System.Collections.Generic;
using System.Net;

using OrmWorkshop.Web.Application.Common.Controllers;

using Xunit;

namespace OrmWorkshop.Web.Application.Tests.NH
{
	public class ProductResourceTests
	{
		public ProductResourceTests()
		{
			DBOperation.Cleanup();
			//ProcessOperation.Cleanup();
			//ProcessOperation.StartNH();
		}

		private readonly string uri = "http://localhost:27967/api/nh/v1/";

		[Fact]
		public void given_a_product_when_persisting_then_successfully_persisted()
		{
			//given
			string name = "test_product_01";

			var client = new RestClient(this.uri);
			var request = new RestRequest("products", Method.POST);

			AddNewProductCommand command = new AddNewProductCommand { Name = name };
			request.AddJsonBody(command);

			//when
			IRestResponse response = client.Execute(request);

			//then
			response.StatusCode.Should().Be(HttpStatusCode.OK, response.Content);

			List<Product> item = DBOperation.ReadAllProducts();

			item.Count.Should().Be(1, "item count !!!");
			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");
		}

		[Fact]
		public void given_two_products_when_persisting_then_successfully_persisted()
		{
			string name = "test_product_01";
			string name2 = "test_product_02";

			var client = new RestClient(this.uri);

			var request = new RestRequest("products", Method.POST);
			request.AddParameter("name", name);

			IRestResponse response = client.Execute(request);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			List<Product> products = DBOperation.ReadAllProducts();

			products.Count.Should().Be(1, "item count !!!");
			products[0].Name.Should().Be(name, "product name !!!");
			products[0].Id.Should().Be(1, "product id !!!");


			request = new RestRequest("products", Method.POST);
			request.AddParameter("name", name2);

			response = client.Execute(request);
			response.StatusCode.Should().Be(HttpStatusCode.OK);

			products = DBOperation.ReadAllProducts();
			products.Count.Should().Be(2, "item count !!!");
			products[0].Name.Should().Be(name, "product name !!!");
			products[0].Id.Should().Be(1, "product id !!!");
			products[1].Name.Should().Be(name2, "product name !!!");
			products[1].Id.Should().Be(2, "product id !!!");
		}

		[Fact]
		public void given_two_products_when_persisting_at_once_then_successfully_persisted()
		{
			//given
			string name = "test_product_01";
			string name2 = "test_product_02";

			var client = new RestClient(this.uri);
			var request = new RestRequest("products/addmany", Method.POST);

			AddNewProductsCommand command = new AddNewProductsCommand { Names = new List<string> { name, name2 } };
			request.AddJsonBody(command);

			//when
			IRestResponse response = client.Execute(request);

			//then
			response.StatusCode.Should().Be(HttpStatusCode.OK, response.Content);

			List<Product> item = DBOperation.ReadAllProducts();

			item.Count.Should().Be(2, "item count !!!");

			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");

			item[1].Name.Should().Be(name2, "product name !!!");
			item[1].Id.Should().Be(2, "product id !!!");
		}


		[Fact]
		public void given_a_product_when_persisting_to_both_then_successfully_persisted()
		{
			//given
			string name = "test_product_01";

			var client = new RestClient(this.uri);
			var request = new RestRequest("products/both", Method.POST);

			AddNewProductCommand command = new AddNewProductCommand() { Name = name };
			request.AddJsonBody(command);

			//when
			IRestResponse response = client.Execute(request);

			//then
			response.StatusCode.Should().Be(HttpStatusCode.OK);

			List<Product> products = DBOperation.ReadAllProducts();
			List<Inventory> inventories = DBOperation.ReadAllInventories();

			products.Count.Should().Be(1, "products count !!!");
			products[0].Name.Should().Be(name, "product name !!!");
			products[0].Id.Should().Be(1, "product id !!!");

			inventories.Count.Should().Be(1, "inventories count !!!");
			inventories[0].Name.Should().Be(name, "inventory name !!!");
			inventories[0].Id.Should().Be(1, "inventory id !!!");
		}
		[Fact]
		public void given_a_product_when_persisting_to_both_with_exception_at_the_end_then_successfully_rollback()
		{
			//given
			string name = "test_product_01";

			var client = new RestClient(this.uri);
			var request = new RestRequest("products/bothexception", Method.POST);

			AddNewProductCommand command = new AddNewProductCommand { Name = name };
			request.AddJsonBody(command);

			//when
			IRestResponse response = client.Execute(request);

			//then
			response.StatusCode.Should().Be(HttpStatusCode.InternalServerError, response.ErrorMessage);
			

			List<Product> products = DBOperation.ReadAllProducts();
			List<Inventory> inventories = DBOperation.ReadAllInventories();

			products.Count.Should().Be(0, "products count !!!");
			inventories.Count.Should().Be(0, "inventories count !!!");
		}


	}
}