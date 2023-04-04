using StringCalculator.Logic.Exceptions;

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

            var delimiters = GetDelimiters(numbers);

            var separatedNumbers = NormalizeNumbersString(numbers)
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return GetSumOfNumbers(separatedNumbers);
        }

        private int GetSumOfNumbers(IEnumerable<string> numbers)
        {
            var negativeNumbers = new List<int>();
            var sum = 0;
            const int maxNumber = 1000;

            foreach (var number in numbers)
            {
                var convertedNumber = !string.IsNullOrEmpty(number) ? int.Parse(number) : 0;

                if (convertedNumber < 0)
                {
                    negativeNumbers.Add(convertedNumber);
                    continue;
                }

                if (convertedNumber > maxNumber)
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

        private string[] GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { @"\n", "," };

            if (!numbers.StartsWith("//"))
            {
                return delimiters.ToArray();
            }

            var customDelimiters = GetCustomDelimiters(numbers);

            delimiters.AddRange(customDelimiters);

            return delimiters.ToArray();
        }
        private string[] GetCustomDelimiters(string numbers)
        {
            var delimiters = new List<string>();
            var delimiterIndex = numbers.IndexOf(@"\n");

            var indexOfStartDelimitersPart = delimiterIndex - 2;
            var delimitersString = numbers.Substring(2, indexOfStartDelimitersPart);

            if (delimitersString.Contains("["))
            {

                var delimitersArray = ParseDelimiters(delimitersString);

                delimiters.AddRange(delimitersArray);
            }
            else
            {
                delimiters.Add(delimitersString);
            }
 
            return delimiters.ToArray();
        }

        // todo refactor
        private IEnumerable<string> ParseDelimiters(string delimitersString)
        {
            var delimiters = new List<string>();
            var startIndex = 0;
            var stack = new Stack<int>();

            for (var i = 0; i < delimitersString.Length; i++)
            {
                if (delimitersString[i] == '[' && !stack.Any())
                {
                    stack.Push(i);
                }
                else if (delimitersString[i] == ']')
                {
                    var nextIndexOfStartSectionChar = delimitersString.IndexOf('[', i);
                    var nextIndexOfEndSectionChar = delimitersString.IndexOf(']', i + 1);

                    if (nextIndexOfStartSectionChar > nextIndexOfEndSectionChar )
                    {
                        continue;
                    } 

                    var start = stack.Pop() + 1;
                    
                    if (start <= i - 1)
                    {
                        delimiters.Add(delimitersString.Substring(start, i - start));
                    }
                }
            }
            return delimiters;
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
