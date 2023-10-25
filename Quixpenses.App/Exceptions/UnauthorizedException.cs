namespace Quixpenses.App.Exceptions;

public class UnauthorizedException : Exception
{
    public long ChatId { get; set; }
}