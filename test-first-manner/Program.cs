namespace StringCalculator.Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();
            //var result = calculator.Add(Console.ReadLine());
            var result = calculator.Add(@"//[]][[]\n1[1[1[1[2]1]1]1]1");
            Console.WriteLine(result);
        }
    }
}