using Microsoft.AspNetCore.Authorization;

namespace RequirementsFromConfig.Requirements;


public class FileBasedAuthenticationRequirement : IAuthorizationRequirement
{

}

public class FileBasedAuthenticationHandler : AuthorizationHandler<FileBasedAuthenticationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FileBasedAuthenticationRequirement requirement)
    {
        // Read from a file to determine if authentication is required
        string filePath = "auth_config.txt";
        bool isAuthRequired = false;

        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath).Trim();
            bool.TryParse(fileContent, out isAuthRequired);
        }

        if (!isAuthRequired || (isAuthRequired && context.User.Identity != null && context.User.Identity.IsAuthenticated))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
