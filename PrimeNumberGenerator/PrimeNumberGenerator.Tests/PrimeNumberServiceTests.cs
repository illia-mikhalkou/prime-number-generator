using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberGenerator.WebApi.Interfaces;
using PrimeNumberGenerator.WebApi.Services.PrimeNumber;
using System;

namespace PrimeNumberGenerator.Tests
{
	[TestClass]
	public class PrimeNumberServiceTests
	{
		private readonly IPrimeNumberService primeNumberService;

		public PrimeNumberServiceTests()
		{
			this.primeNumberService = new PrimeNumberService();
		}

		[TestMethod]
		public void TestPrimeNumbers()
		{
			Assert.IsTrue(this.primeNumberService.IsPrime(2));
			Assert.IsTrue(this.primeNumberService.IsPrime(5));
			Assert.IsTrue(this.primeNumberService.IsPrime(149));
			Assert.IsTrue(this.primeNumberService.IsPrime(11777));
			Assert.IsTrue(this.primeNumberService.IsPrime(25747));
			Assert.IsTrue(this.primeNumberService.IsPrime(99991));
		}

		[TestMethod]
		public void TestNonPrimeNumbers()
		{
			Assert.IsFalse(this.primeNumberService.IsPrime(4));
			Assert.IsFalse(this.primeNumberService.IsPrime(25));
			Assert.IsFalse(this.primeNumberService.IsPrime(169));
			Assert.IsFalse(this.primeNumberService.IsPrime(18045));
			Assert.IsFalse(this.primeNumberService.IsPrime(25749));
		}

		[TestMethod]
		public void TestExceptions()
		{
			Assert.ThrowsException<ArgumentException>(() => this.primeNumberService.IsPrime(-1));
			Assert.ThrowsException<ArgumentException>(() => this.primeNumberService.IsPrime(int.MinValue));
			Assert.ThrowsException<ArgumentException>(() => this.primeNumberService.IsPrime(0));
		}
	}
}
