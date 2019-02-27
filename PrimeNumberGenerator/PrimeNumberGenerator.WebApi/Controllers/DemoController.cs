using PrimeNumberGenerator.WebApi.Models;
using System.Collections.Concurrent;
using System.Web.Http;

namespace PrimeNumberGenerator.WebApi.Controllers
{
	public class DemoController : ApiController
    {
		private static readonly ConcurrentDictionary<int, string> Storage = new ConcurrentDictionary<int, string>();

		public string Get(int number)
		{
			if (Storage.TryGetValue(number, out string result))
			{
				return result;
			}

			return null;
		}

		[HttpPost]
		[Route("api/demo")]
		public DemoObject Post([FromBody]DemoObject body)
		{
			Storage.TryAdd(body.Number, body.Message);

			return new DemoObject { Number = body.Number * 2, Message = $"{body.Message} {body.Message}" };
		}
	}
}
