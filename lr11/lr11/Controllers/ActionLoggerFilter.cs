using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

public class ActionLoggerFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        string logPath = "action_log.txt";
        string logEntry = $"Method: {context.ActionDescriptor.DisplayName}, Time: {DateTime.Now}\n";
        File.AppendAllText(logPath, logEntry);
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
