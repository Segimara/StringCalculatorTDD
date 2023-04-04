using StringCalculator.Logic.Exceptions;

namespace StringCalculator.Logic
{
    public class StringCalculator 
    {
        public virtual int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = GetDelimiters(numbers);

            var separatedNumbers = NormalizeNumbersString(numbers)
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return GetSumOfNumbers(separatedNumbers);
        }

        private int GetSumOfNumbers(IEnumerable<string> numbers)
        {
            var maxNumber = 1000;

            var convertedNumbers = numbers
                .Select(number => !string.IsNullOrEmpty(number) ? int.Parse(number) : 0);

            var negativeNumbers = convertedNumbers.Where(number => number < 0);

            if (negativeNumbers.Any())
            {
                throw new NegativeNumberException(negativeNumbers);
            }

            return convertedNumbers
                .Where(number => number <= maxNumber)
                .Sum();
        }

        private string[] GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { @"\n", "," };

            if (numbers.StartsWith("//"))
            {
                var customDelimiters = GetCustomDelimiters(numbers);

                delimiters.AddRange(customDelimiters);
            }

            return delimiters.ToArray();
        }
        private IEnumerable<string> GetCustomDelimiters(string numbers)
        {
            var delimiters = new List<string>();

            var lengthDelimitersPart = numbers.IndexOf(@"\n") - 2;
            var delimitersString = numbers.Substring(2, lengthDelimitersPart);

            if (delimitersString.Contains("["))
            {
                var customDelimiters = ParseDelimiters(delimitersString);

                delimiters.AddRange(customDelimiters);
            }
            else
            {
                delimiters.Add(delimitersString);
            }
 
            return delimiters;
        }

        private IEnumerable<string> ParseDelimiters(string delimitersString)
        {
            var delimiters = new List<string>();

            for (var i = 0; i < delimitersString.Length; i++)
            {
                if (delimitersString[i] != '[') continue;

                var lengthOfDelimiter = GetDelimiterLength(delimitersString, i);
                    
                var delimiter = delimitersString.Substring(i + 1, lengthOfDelimiter);

                delimiters.Add(delimiter);

                i += lengthOfDelimiter;
            }

            return delimiters;
        }

        private int GetDelimiterLength(string delimitersString, int startIndex)
        {
            for (var i = startIndex; i < delimitersString.Length; i++)
            {
                if (delimitersString[i] != ']') continue;

                var lengthOfDelimiter =  i - startIndex - 1;

                if (lengthOfDelimiter <= 0) continue;

                return lengthOfDelimiter;
            }

            return delimitersString.Length;
        }
        private string NormalizeNumbersString(string numbers)
        {
            if (numbers.Contains("//"))
            {
                var indexOfEndDelimitersPart = numbers.IndexOf(@"\n") + 2;
                numbers = numbers.Substring(indexOfEndDelimitersPart);
            }

            return numbers;
        }
    }
}
