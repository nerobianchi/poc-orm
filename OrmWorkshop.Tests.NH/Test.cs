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

using System.Collections.Generic;

using FluentAssertions;

using OrmWorkshop.Domain;
using OrmWorkshop.Tests.Common;

using Xunit;

namespace OrmWorkshop.Tests.NH
{
	public class Test
	{
		[Fact]
		public void given_a_product_when_persisting_then_successfully_persisted()
		{
			DBOperation.Cleanup();

			Product product = new Product();
			string name = "test_product_01";
			product.Name = name;

			Bootstrapper.Initialize();
			IProductService service = Bootstrapper.Resolve<IProductService>();
			service.AddNewProduct(product);

			List<Product> item = DBOperation.Read<Product>("select * from tblProduct order by Id asc");

			item.Count.Should().Be(1, "item count !!!");
			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");
		}
		[Fact]
		public void given_two_products_when_persisting_then_successfully_persisted()
		{
			DBOperation.Cleanup();

			Product product = new Product();
			string name = "test_product_01";
			product.Name = name;

			Product product2 = new Product();
			string name2 = "test_product_02";
			product2.Name = name2;

			Bootstrapper.Initialize();

			IProductService service = Bootstrapper.Resolve<IProductService>();

			service.AddNewProduct(product);
			service.AddNewProduct(product2);

			List<Product> item = DBOperation.Read<Product>("select * from tblProduct order by Id asc");

			item.Count.Should().Be(2, "item count !!!");

			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");

			item[1].Name.Should().Be(name2, "product name !!!");
			item[1].Id.Should().Be(2, "product id !!!");
		}
		[Fact]
		public void given_two_products_when_persisting_at_once_then_successfully_persisted()
		{
			DBOperation.Cleanup();

			Product product = new Product();
			string name = "test_product_01";
			product.Name = name;

			Product product2 = new Product();
			string name2 = "test_product_02";
			product2.Name = name2;

			List<Product> productList = new List<Product>() { product, product2 };

			Bootstrapper.Initialize();

			IProductService service = Bootstrapper.Resolve<IProductService>();

			service.AddNewProducts(productList);


			List<Product> item = DBOperation.Read<Product>("select * from tblProduct order by Id asc");

			item.Count.Should().Be(2, "item count !!!");

			item[0].Name.Should().Be(name, "product name !!!");
			item[0].Id.Should().Be(1, "product id !!!");

			item[1].Name.Should().Be(name2, "product name !!!");
			item[1].Id.Should().Be(2, "product id !!!");
		}
	}

	//public class DBOperation
	//{
	//	public static void Cleanup()
	//	{
	//		string readAllText = "truncate table tblProduct";

	//		using (SqlCommand command = new SqlCommand(readAllText)
	//											 {
	//												 Connection = new SqlConnection(DBOperation.GetConnectionString()),
	//												 CommandType = CommandType.Text,
	//											 })
	//		{
	//			if (command.Connection.State != ConnectionState.Open)
	//			{
	//				command.Connection.Open();
	//			}

	//			command.ExecuteNonQuery();
	//		}
	//	}

	//	public static List<T> Read<T>(string commandText, params SqlParameter[] parameters)
	//	{
	//		return Read<T>(commandText, DBOperation.GetConnectionString(), parameters);
	//	}

	//	private static string GetConnectionString()
	//	{
	//		return new ApplicationConfigurationManager().ApplicationConfiguration.DatabaseSetting.DefaultConnectionString;
	//	}

	//	public static List<T> Read<T>(string commandText, string connectionString, params SqlParameter[] parameters)
	//	{
	//		List<T> result;

	//		using (SqlCommand command = new SqlCommand(commandText)
	//		{
	//			Connection = new SqlConnection(connectionString),
	//			CommandType = CommandType.Text,
	//		})
	//		{
	//			command.Parameters.AddRange(parameters);

	//			if (command.Connection.State != ConnectionState.Open)
	//			{
	//				command.Connection.Open();
	//			}

	//			DataSet ds = new DataSet();
	//			SqlDataAdapter adapter = new SqlDataAdapter(command);
	//			adapter.Fill(ds);

	//			if (command.Connection.State == ConnectionState.Open)
	//			{
	//				command.Connection.Close();
	//			}

	//			result = AutoMapper.Mapper.DynamicMap<IDataReader, List<T>>(ds.Tables[0].CreateDataReader());
	//		}
	//		return result;
	//	}
	//}
}