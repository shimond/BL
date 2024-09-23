using UseLogging.Contracts;

namespace UseLogging.Services;


public class MyService(ILogger<MyService> logger) : IMyService
{
    public void Do()
    {
        logger.LogInformation("Logging from Do {username}", "shimond dahan");
		try
		{
			int x = 0;
            var val = 10 / x;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Error in Do");
            //throw;
		}
    }

}
