namespace StringCalculator.Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(Console.ReadLine());
            Console.WriteLine(result);
        }
    }
}