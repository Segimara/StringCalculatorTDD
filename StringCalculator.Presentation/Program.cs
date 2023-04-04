namespace StringCalculator.Presentation
{
    using StringCalculator.Logic;

    public class Program
    {
        public StringCalculator Calculator { get; set; }
        public ConsoleManager ConsoleManager { get; }

        public Program(ConsoleManager consoleManager, Logic.StringCalculator calculator)
        {
            ConsoleManager = consoleManager;
            Calculator = calculator;
        }

        static void Main(string[] args)
        {
            var calculator = new Logic.StringCalculator();
            var consoleManager = new ConsoleManager();
            var program = new Program(consoleManager, calculator);
            program.Run();
        }

        public void Run()
        {
                ConsoleManager.WriteLine("Enter comma separated numbers (enter to exit):");
            while (true)
            {
                var input = ConsoleManager.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                ExecuteAndGetResult(input, Calculator);


                ConsoleManager.WriteLine("you can enter other numbers (enter to exit)?");
            }
        }

        private void ExecuteAndGetResult(string input, Logic.StringCalculator calculator)
        {
            var result = calculator.Add(input);
            ConsoleManager.WriteLine($"Result is: {result}");
        }
    }
}