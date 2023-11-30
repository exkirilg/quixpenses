namespace Quixpenses.Common.Exceptions;

public class UnableToCreateTransactionException : Exception
{
    public UnableToCreateTransactionException() : base()
    {
    }

    public UnableToCreateTransactionException(string message) : base(message)
    {
    }

    public UnableToCreateTransactionException(string message, Exception inner) : base(message, inner)
    {
    }
}