using System.Web.Http;

namespace WebApi.Controllers
{
	[RoutePrefix("api")]
	public class HealthCheckController : ApiController
	{
		[HttpGet]
		[Route("healthCheck")]
		public IHttpActionResult GetHealthCheckStatus()
		{
			return Ok(new
			{
				Status = "UP",
				LastStartDate = WebApiHost.StartDate.ToString("yyyy-mm-dd:HH:mm:ss")
			});
		}

	}
}
