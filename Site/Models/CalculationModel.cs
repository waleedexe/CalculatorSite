using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class CalculationModel
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Result { get; set; }
        public List<string> Errors { get; set; }

        public CalculationModel()
        {
            Errors = new List<string>();
        }
    }
}