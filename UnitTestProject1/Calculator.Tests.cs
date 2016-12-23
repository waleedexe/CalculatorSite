using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Calculator
    {
        Services.Calculator _sut = null;

        [TestInitialize]
        public void Init()
        {
            _sut = new Services.Calculator();
        }

        [TestMethod]
        public void AddPostivies_Should_BePositive()
        {
            var largeNumber1 = "99999999";

            var result = _sut.Add(largeNumber1, "1");

            Assert.IsFalse(result.Contains("-"));
            Assert.IsTrue(result.Length > largeNumber1.Length);
        }

        [TestMethod]
        public void AddMixedLargePositive_Should_BePositive()
        {
            var largeNumber1 = "99999999";

            var result = _sut.Add(largeNumber1, "-1");

            Assert.IsFalse(result.Contains("-"));
        }

        [TestMethod]
        public void AddMixedLargeNegative_Should_BeNegative()
        {
            var largeNumber1 = "-99999999";

            var result = _sut.Add(largeNumber1, "1");

            Assert.IsTrue(result.Contains("-"));
        }

        [TestMethod]
        public void AddMixedSame_Should_Zero()
        {
            var largeNumber1 = "-99999999";

            var result = _sut.Add(largeNumber1, "99999999");

            Assert.AreEqual("0", result);
        }
    }
}
