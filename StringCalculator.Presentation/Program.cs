namespace StringCalculator.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Logic.StringCalculator();
            var consoleManager = new ConsoleManager();
            var application = new CalculatorApplication(consoleManager, calculator);
            application.Run();
        }
    }
}