using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Interfaces;
using Site.Models;
using System.Web.Http.Results;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorApiTests
    {
        Site.Controllers.CalculatorController _sut = null;
        Mock<ICalculator> _calcMock = null;
        Mock<IDataValidator> _validator = null;

        [TestInitialize]
        public void Init()
        {
            _calcMock = new Mock<ICalculator>();
            _validator = new Mock<IDataValidator>();

            _sut = new Site.Controllers.CalculatorController(_calcMock.Object, _validator.Object);
        }

        [TestMethod]
        public void InvalidDate_Should_NotCalculate()
        {
            var sample = new CalculationModel { FirstNumber = "1", SecondNumber = "2" };
            _validator.Setup(m => m.IsNumberValid(It.IsAny<string>())).Returns(false);

            var result = _sut.PostCalculation(new CalculationModel());

            _calcMock.Verify(m => m.Add(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void ValidDate_Should_Calculate()
        {
            var sample = new CalculationModel { FirstNumber = "1", SecondNumber = "2" };
            _validator.Setup(m => m.IsNumberValid(It.IsAny<string>())).Returns(true);

            var result = _sut.PostCalculation(sample);

            _calcMock.Verify(m => m.Add(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
