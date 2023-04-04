namespace StringCalculator.Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();
            
            while (true)
            {
                PrintMenu();
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                ExecuteAndGetResult(input, calculator);
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Enter comma separated numbers (enter to exit):");
        }

        private static void ExecuteAndGetResult(string input, StringCalculator calculator)
        {
            var result = calculator.Add(input);
            Console.WriteLine($"Result is: {result}");

            PrintMenu();
        }
    }
}