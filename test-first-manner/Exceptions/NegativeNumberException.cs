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
        public bool HasNegativeNumbers
        {
            get
            {
                return _negateveNumbers.Any();
            }
        }
        private List<int> _negateveNumbers;
        public override string Message
        {
            get
            {
                return $"negatives not allowed\n Numbers: {string.Join(',', _negateveNumbers)}";
            }
        }
        public NegativeNumberException() : base()
        {
            _negateveNumbers = new List<int>();
        }
        public NegativeNumberException(string message) : base(message) { }

        public NegativeNumberException(int number) : this()
        {
            _negateveNumbers.Add(number);
        }
        public void AddNegateveNumber(int number)
        {
            _negateveNumbers.Add(number);
        }
    }
}
