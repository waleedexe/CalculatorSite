using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class Validator
	{
        Services.NumberValidator _sut = null;

        [TestInitialize]
		public void Init()
        {
            _sut = new Services.NumberValidator();
        }

		[TestMethod]
		public void DecimalNumber_Should_Fail()
		{
            var result = _sut.IsNumberValid("1.1");

            Assert.IsFalse(result);
		}

        [TestMethod]
        public void AlphaNumber_Should_Fail()
        {
            var result = _sut.IsNumberValid("123x");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Number_Should_Pass()
        {
            var result = _sut.IsNumberValid("12345677901234567890");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NegativeNumber_Should_Pass()
        {
            var result = _sut.IsNumberValid("-123");

            Assert.IsTrue(result);
        }
    }
}
