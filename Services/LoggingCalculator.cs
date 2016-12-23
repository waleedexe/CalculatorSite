using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoggingCalculator : ICalculator
    {
        private readonly ICalculator _calculator;
        private readonly ILogWriter _logger;

        public LoggingCalculator(ICalculator calculator, ILogWriter logger)
        {
            _calculator = calculator;
            _logger = logger;
        }

        public string Add(string num1, string num2)
        {
            var result = _calculator.Add(num1, num2);

            _logger.Log($"{DateTime.Now}, {num1}, {num2}, {result}");

            return result;
        }
    }
}
