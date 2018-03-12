using PrimeNumberGenerator.WebApi.Interfaces;
using System.Web.Http;

namespace PrimeNumberGenerator.WebApi.Controllers
{
	public class PrimeNumberController : ApiController
	{
		private readonly IPrimeNumberService primeNumberService;

		public PrimeNumberController(IPrimeNumberService primeNumberService)
		{
			this.primeNumberService = primeNumberService;
		}

		public bool Get(int number)
		{
			return this.primeNumberService.IsPrime(number);
		}
	}
}