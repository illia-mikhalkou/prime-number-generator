using System.Web.Mvc;

namespace PrimeNumberGenerator.WebApi.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
