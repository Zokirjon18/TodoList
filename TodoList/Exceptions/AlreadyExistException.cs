namespace TodoList.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public int StatusCode { get; }

        public AlreadyExistException(string message) : base(message)
        {
            StatusCode = 409;
        }
    }

    public class ArgumentNotValid : Exception
    {
        public int StatusCode { get; }

        public ArgumentNotValid(string message) : base(message)
        {
            StatusCode = 400;
        }
    }
}
