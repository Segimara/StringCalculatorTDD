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
            return normilizeNumbers.Split(delimiterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => StringToNumber(x))
                .Sum();
        }
        private int StringToNumber(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                var number = int.Parse(str);
                if (number < 0)
                {
                    throw new Exception("negatives not allowed");
                }
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
