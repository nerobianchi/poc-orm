using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using AutoMapper;

using OrmWorkshop.Configuration;
using OrmWorkshop.Domain;

namespace OrmWorkshop.Tests.Common
{
	public class DBOperation
	{
		public static void Cleanup()
		{
			string readAllText = @"truncate table tblProduct
truncate table tblInventory";

			using (SqlCommand command = new SqlCommand(readAllText)
												 {
													 Connection = new SqlConnection(GetConnectionString()),
													 CommandType = CommandType.Text
												 })
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}

				command.ExecuteNonQuery();
			}
		}

		public static List<T> Read<T>(string commandText, params SqlParameter[] parameters)
		{
			return Read<T>(commandText, GetConnectionString(), parameters);
		}

		private static string GetConnectionString()
		{
			return new ApplicationConfigurationManager().ApplicationConfiguration.DatabaseSetting.DefaultConnectionString;
		}

		public static List<T> Read<T>(string commandText, string connectionString, params SqlParameter[] parameters)
		{
			List<T> result;

			using (SqlCommand command = new SqlCommand(commandText)
												 {
													 Connection = new SqlConnection(connectionString),
													 CommandType = CommandType.Text
												 })
			{
				command.Parameters.AddRange(parameters);

				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}

				DataSet ds = new DataSet();
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(ds);

				if (command.Connection.State == ConnectionState.Open)
				{
					command.Connection.Close();
				}

				result = Mapper.DynamicMap<IDataReader, List<T>>(ds.Tables[0].CreateDataReader());
			}
			return result;
		}

		public static void CreateOneProduct()
		{
			string readAllText = @"truncate table tblProduct
insert into tblProduct(Name) values ('test_product_01')
";

			using (SqlCommand command = new SqlCommand(readAllText)
												 {
													 Connection = new SqlConnection(GetConnectionString()),
													 CommandType = CommandType.Text
												 })
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}

				command.ExecuteNonQuery();
			}
		}

		public static void CreateTwoProducts()
		{
			string readAllText = @"truncate table tblProduct
insert into tblProduct(Name) values ('test_product_01')
insert into tblProduct(Name) values ('test_product_02')
";

			using (SqlCommand command = new SqlCommand(readAllText)
												 {
													 Connection = new SqlConnection(GetConnectionString()),
													 CommandType = CommandType.Text
												 })
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}

				command.ExecuteNonQuery();
			}
		}

		public static List<Product> ReadAllProducts()
		{
			return Read<Product>("select * from tblProduct order by Id asc");
		}

		public static List<Inventory> ReadAllInventories()
		{
			return Read<Inventory>("select * from tblInventory order by Id asc");
		}
	}
}