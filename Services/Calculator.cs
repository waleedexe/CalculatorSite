using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Calculator : ICalculator
    {
        public string Add(string num1, string num2)
        {
            var n1 = BigInteger.Parse(num1);
            var n2 = BigInteger.Parse(num2);

            var result = n1 + n2;

            return result.ToString();

        }
    }
}
