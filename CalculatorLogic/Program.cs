namespace StringCalculator.Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();
            PrintMenu();
            var input = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(input))
                    break;

                var result = calculator.Add(input);
                Console.WriteLine($"Result is: {result}");

                PrintMenu();

                input = Console.ReadLine();
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Enter comma separated numbers (enter to exit):");
        }
    }
}