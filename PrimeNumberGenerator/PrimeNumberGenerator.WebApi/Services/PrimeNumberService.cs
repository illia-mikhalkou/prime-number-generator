using PrimeNumberGenerator.WebApi.Interfaces;
using System;

namespace PrimeNumberGenerator.WebApi.Services
{
	public class PrimeNumberService : IPrimeNumberService
	{
		public bool IsPrime(int number)
		{
			return this.CheckIfPrime(number);
		}

		private bool CheckIfPrime(int number)
		{
			if(number <= 3)
			{
				return true;
			}

			if(number % 2 == 0 || number % 3 == 0)
			{
				return false;
			}

			var upperBound = (int)Math.Ceiling(Math.Sqrt(number));

			for(var i = 5; i <= upperBound; i+=6)
			{
				if(number % i == 0 || number % (i + 2) == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}