namespace Quixpenses.Common.Exceptions;

public class UnableToCreateInviteException : Exception
{
    public UnableToCreateInviteException() : base()
    {
    }

    public UnableToCreateInviteException(string message) : base(message)
    {
    }

    public UnableToCreateInviteException(string message, Exception inner) : base(message, inner)
    {
    }
}