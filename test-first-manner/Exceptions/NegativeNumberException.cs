using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logic.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(List<int> numbers) : base($"negatives not allowed\n Nubers: {string.Join(",", numbers)}") {}
    }
}
