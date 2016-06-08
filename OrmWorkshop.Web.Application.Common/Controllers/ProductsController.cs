#region licence

// <copyright file="ProductsController.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	OrmWorkshop.Web.Application.Common
// 	Created By: 	erdem.ozdemir
// 	Create Date:	01.06.2016 17:16
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	07.06.2016 15:31
// </summary>

#endregion

using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

using OrmWorkshop.Domain;

namespace OrmWorkshop.Web.Application.Common.Controllers
{
	[RoutePrefix("products")]
	public class ProductsController : ApiController
	{
		private readonly IProductService productService;

		public ProductsController(IProductService productService)
		{
			this.productService = productService;
		}

		[Route("")]
		[HttpPost]
		public IHttpActionResult AddNewProduct(AddNewProductCommand command)
		{
			this.productService.AddNewProduct(new Product
			                                  {
				                                  Name = command.Name
			                                  });

			return new OkResult(this);
		}

		[Route("both")]
		[HttpPost]
		public IHttpActionResult AddNewProductBoth(AddNewProductCommand command)
		{
			this.productService.AddNewProductBoth(new ProductDto
			                                      {
				                                      Name = command.Name
			                                      });

			return new OkResult(this);
		}

		[Route("bothexception")]
		[HttpPost]
		public IHttpActionResult AddNewProductBothException(AddNewProductCommand command)
		{
			this.productService.AddNewProductBothException(new ProductDto
			                                               {
				                                               Name = command.Name
			                                               });

			return new OkResult(this);
		}

		[Route("addmany")]
		[HttpPost]
		public IHttpActionResult AddNewProducts(AddNewProductsCommand command)
		{
			try
			{
				List<Product> productList = new List<Product>();
				foreach (var name in command.Names)
				{
					productList.Add(new Product()
					                {
						                Name = name
					                });
				}
				this.productService.AddNewProducts(productList);

				return new OkResult(this);
			}
			catch (System.Exception ex)
			{
				return new ExceptionResult(ex, this);
			}
		}

		[Route("")]
		[HttpGet]
		public JsonResult<List<Product>> Get()
		{
			return Json(this.productService.ListAllProducts());
		}
	}
}