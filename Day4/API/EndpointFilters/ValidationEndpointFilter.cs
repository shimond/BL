
using API.Validation;
using System.ComponentModel.DataAnnotations;

namespace API.EndpointFilters;

public class ValidationEndpointFilter(ILogger<ValidationEndpointFilter> logger) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validationResults = new List<ValidationResult>();
        foreach (var item in context.Arguments.Select(x => x as IBackendValidation).Where(o => o != null))
        {
            var validationContext = new ValidationContext(item);

            if (!Validator.TryValidateObject(item, validationContext, validationResults, true))
            {
                return TypedResults.BadRequest(validationResults);
            }
        }

        var res = await next(context);
        return res;
    }
}
