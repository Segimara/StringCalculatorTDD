namespace StringCalculator.Presentation
{
    public class ConsoleManager 
    {
        public virtual void Write(string value)
        {
            Console.Write(value);
        }

        public virtual void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public virtual string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
