using PrimeNumberGenerator.WebApi.Interfaces;
using System;
using System.Collections.Concurrent;

namespace PrimeNumberGenerator.WebApi.Services.PrimeNumber
{
	public class PrimeNumberService : IPrimeNumberService
	{
		public static readonly ConcurrentDictionary<int, bool> cache = new ConcurrentDictionary<int, bool>();

		public bool IsPrime(int number)
		{
			if (number < 1)
			{
				throw new ArgumentException(nameof(number));
			}

			if (cache.TryGetValue(number, out bool existingResult))
			{
				return existingResult;
			}

			var result = this.CheckIfPrime(number);
			cache.TryAdd(number, result);

			return result;
		}

		private bool CheckIfPrime(int number)
		{
			if(number <= 3)
			{
				return true;
			}

			//Separated check for divisibility by 2 and 3 allow to increase step of the loop from 2 to 6.
			if (number % 2 == 0 || number % 3 == 0)
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