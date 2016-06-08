using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace OrmWorkshop.Web.Application.Asd
{
	public class GlobalExceptionHandler : ExceptionHandler
	{
		public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
		{
			// Access Exception
			// var exception = context.Exception;

			string genericErrorMessage = "An unexpected error occured";
			var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
				new
				{
					Message = genericErrorMessage
				});

			response.Headers.Add("X-Error", genericErrorMessage);
			context.Result = new ResponseMessageResult(response);
		}
	}
}