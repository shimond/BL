namespace API.ExceptionHandlers;

public class ItemResultExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ItemResultException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await httpContext.Response.WriteAsync(exception.Message, cancellationToken);
            return true;
        }
        return false;
    }
}
