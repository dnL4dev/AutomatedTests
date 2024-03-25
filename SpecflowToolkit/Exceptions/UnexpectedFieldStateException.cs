namespace SpecflowToolkit.Exceptions
{
    public class UnexpectedFieldStateException : Exception
    {
        public UnexpectedFieldStateException()
        {
        }

        public UnexpectedFieldStateException(string message) : base(message)
        {
        }

        public UnexpectedFieldStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
