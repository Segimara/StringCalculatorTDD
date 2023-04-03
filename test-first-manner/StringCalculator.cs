using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_first_manner
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            string DefaultDelimiter = ",";
            if (numbers.StartsWith("//"))
            {
                int delimiterIndex = numbers.IndexOf('\n');
                DefaultDelimiter = numbers.Substring(2, delimiterIndex - 2);
                numbers = numbers.Substring(delimiterIndex + 1);
            }
            return numbers.Split(new string[] { DefaultDelimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x =>
            {
                if (!string.IsNullOrEmpty(x))
                {
                    return int.Parse(x);
                }
                return 0;
            })
            .DefaultIfEmpty(0)
            .Sum();
        }
    }
}
