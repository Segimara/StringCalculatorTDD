namespace StringCalculator.Logic.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(IEnumerable<int> numbers) : base($"negatives not allowed\n Numbers: {string.Join(",", numbers)}") { }
    }
}
