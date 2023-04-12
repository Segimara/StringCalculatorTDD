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

            var convertedNumbers = separatedNumbers
                .Select(number => !string.IsNullOrEmpty(number.ToString()) ? int.Parse(number.ToString()) : 0);

            return GetSumOfNumbers(convertedNumbers);
        }

        private int GetSumOfNumbers(IEnumerable<int> numbers)
        {
            var maxNumber = 1000;

            var negativeNumbers = numbers.Where(number => number < 0);

            if (negativeNumbers.Any())
            {
                throw new NegativeNumberException(negativeNumbers);
            }

            return numbers
                .Where(number => number <= maxNumber)
                .Sum();
        }

        private string[] GetDelimiters(string numbers)
        {
            var delimiters = new List<string>();

            if (numbers.StartsWith("//"))
            {
                var customDelimiters = GetCustomDelimiters(numbers);

                delimiters.AddRange(customDelimiters);
            }

            delimiters.AddRange(GetDefaultDelimiters());

            return delimiters.ToArray();
        }

        private IEnumerable<string> GetDefaultDelimiters()
        {
            return new[] { @"\n", "," };
        }

        private IEnumerable<string> GetCustomDelimiters(string numbers)
        {
            var delimiters = new List<string>();

            var lengthDelimitersPart = numbers.IndexOf(@"\n") - 2;
            var delimitersString = numbers.Substring(2, lengthDelimitersPart);

            var minimalLengthOfDelimitersString = 3;

            if (delimitersString.Length >= minimalLengthOfDelimitersString)
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
            var delimitersStringWithoutFirstAndLastChar = delimitersString.Substring(1, delimitersString.Length - 2);

            return delimitersStringWithoutFirstAndLastChar.Split("][");
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
