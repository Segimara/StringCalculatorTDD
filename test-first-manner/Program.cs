namespace StringCalculator.Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();

            var input = Console.ReadLine();

            var result = calculator.Add(input);
            Console.WriteLine(result);
        }
    }
}