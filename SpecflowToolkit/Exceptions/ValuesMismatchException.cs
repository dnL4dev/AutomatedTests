namespace SpecflowToolkit.Exceptions
{
    public class ValuesMismatchException : Exception
    {
        public ValuesMismatchException()
        {
        }

        public ValuesMismatchException(string message) : base(message)
        {
        }

        public ValuesMismatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
