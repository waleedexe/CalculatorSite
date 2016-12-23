using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Site.Controllers
{
    public class CalculatorController : ApiController
    {
        private readonly ICalculator _calculator;
        private readonly IDataValidator _validator;

        public CalculatorController(ICalculator calculator, IDataValidator validator)
        {
            _calculator = calculator;
            _validator = validator;
        }

        [HttpPost]
        public IHttpActionResult PostCalculation(Models.CalculationModel model)
        {
            if (!IsValid(model))
                return Ok(model);

            model.Result = _calculator.Add(model.FirstNumber, model.SecondNumber);

            return Ok(model);
        }

        private bool IsValid(Models.CalculationModel model)
        {
            if (!_validator.IsNumberValid(model.FirstNumber))
                model.Errors.Add("First number is not valid.");
            if (!_validator.IsNumberValid(model.SecondNumber))
                model.Errors.Add("Second number is not valid.");

            return !model.Errors.Any();
        }

    }
}
