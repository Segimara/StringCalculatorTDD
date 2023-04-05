namespace StringCalculator.Presentation
{
    public class CalculatorApplication
    {
        private Logic.StringCalculator _calculator { get; set; }
        private ConsoleManager _consoleManager { get; }

        public CalculatorApplication(ConsoleManager consoleManager, Logic.StringCalculator calculator)
        {
            _consoleManager = consoleManager;
            _calculator = calculator;
        }

        public void Run()
        {
            _consoleManager.WriteLine("Enter comma separated numbers (enter to exit):");
            while (true)
            {
                var input = _consoleManager.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                ExecuteAndGetResult(input, _calculator);


                _consoleManager.WriteLine("you can enter other numbers (enter to exit)?");
            }
        }

        private void ExecuteAndGetResult(string input, Logic.StringCalculator calculator)
        {
            var result = calculator.Add(input);
            _consoleManager.WriteLine($"Result is: {result}");
        }
    }
}
