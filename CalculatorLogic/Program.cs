namespace StringCalculator.Logic
{
    public class Program
    {
        static void Main()
        {
            var calculator = new StringCalculator();
            var input = Console.ReadLine();
            var result = calculator.Add(input);
            Console.WriteLine(result);
        }
    }
}
