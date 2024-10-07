namespace API.Exceptions;

public enum ItemResultExceptionType
{
    NotFound = 404, Conflict = 409
}
public class ItemResultException : Exception
{
    public ItemResultExceptionType ExceptionType { get; set; }
    public ItemResultException(string message) : base(message)
    {
    }
}
