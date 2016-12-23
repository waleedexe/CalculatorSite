using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class NumberValidator : IDataValidator
    {
        public bool IsNumberValid(string number)
        {
            var rgx = new Regex(@"^-?[0-9]\d*?$", RegexOptions.Compiled);
            return rgx.IsMatch(number);
        }
    }
}
