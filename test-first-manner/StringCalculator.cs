using StringCalculator.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logic
{
    public class StringCalculator
    {
        private const string CUSTOM_DELIMITER_START_SING = "//";
        private const string CUSTOM_DELIMITER_END_SING = "\n";
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            var delimiterList = GetGetDelimiterList(numbers)
                                .ToArray();
            var normilizeNumbers = NormilizeString(numbers);
            var separatedNumbers = normilizeNumbers.Split(delimiterList, StringSplitOptions.RemoveEmptyEntries);
            return GetSumOfSeparatedNumbers(separatedNumbers);
        }

        private int GetSumOfSeparatedNumbers(string[] separatedNumbers)
        {
            var negativeNumberException = new NegativeNumberException();
            int sum = 0;    
            foreach ( var stringNumber in separatedNumbers)
            {
                var number = StringToNumber(stringNumber);
                if (number < 0)
                {
                    negativeNumberException.AddNegateveNumber(number);
                    continue;
                }
                sum += number;
            }
            if (negativeNumberException.HasNegativeNumbers)
            {
                throw negativeNumberException;
            }
            return sum;
        }

        private int StringToNumber(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                var number = int.Parse(str);
                return number;
            }
            return 0;
        }
        private List<string> GetGetDelimiterList(string numbers)
        {
            List<string> delimetrs = new List<string>();
            delimetrs.Add("\n");
            delimetrs.Add(",");
            if (numbers.StartsWith(CUSTOM_DELIMITER_START_SING))
            {
                int delimiterIndex = numbers.IndexOf('\n');
                delimetrs.Add(numbers.Substring(2, delimiterIndex - 2));
            }
            return delimetrs;
        }
        private string NormilizeString(string numbers)
        {

            if (numbers.Contains(CUSTOM_DELIMITER_START_SING))
            {
                numbers = numbers.Substring(numbers.IndexOf(CUSTOM_DELIMITER_END_SING) + 1);
            }
            return numbers;
        }
    }
}
