using StringCalculator.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logic
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimeterList = GetDelimiters(numbers)
                                .ToArray();

            var separatedNumbers = NormilizeNumbersString(numbers).Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            return GetSumOfNumbers(separatedNumbers);
        }

        private int GetSumOfNumbers(string[] numbers)
        {
            List<int> negativeNumbers = new List<int>();
            int sum = 0;    

            foreach ( var number in numbers)
            {
                var convertedNumber = (!string.IsNullOrEmpty(number)) ? int.Parse(number) : 0;
                if (convertedNumber < 0)
                {
                    negativeNumbers.Add(convertedNumber);
                    continue;
                }
                if (convertedNumber > 1000)
                {
                    continue;
                }
                sum += convertedNumber;
            }

            if (negativeNumbers.Any())
            {
                throw new NegativeNumberException(negativeNumbers);
            }

            return sum;
        }

        private IList<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>()
            {
                "\n",
                ","
            };

            if (numbers.StartsWith("//"))
            {
                var delimeterIndex = numbers.IndexOf('\n');

                var indexOfEndDelimetersPart = delimeterIndex - 2;
                var delimitersString = numbers.Substring(2, indexOfEndDelimetersPart);

                if (delimitersString.Contains("["))
                {
                    var delimitersArray = delimitersString.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var delimiter in delimitersArray)
                    {
                        delimiters.Add(delimiter);
                    }
                }

                else
                {
                    delimiters.Add(delimitersString);
                }

                
            }

            return delimiters;
        }
        private string NormilizeNumbersString(string numbers)
        {
            if (numbers.Contains("//"))
            {
                var indexOfEndDelimimitersPart = numbers.IndexOf("\n") + 1;
                numbers = numbers.Substring(indexOfEndDelimimitersPart);
            }

            return numbers;
        }
    }
}
