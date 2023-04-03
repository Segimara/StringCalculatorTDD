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
            return numbers.Split(',', '\n').Select(x =>
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
