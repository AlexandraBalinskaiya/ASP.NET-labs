using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.IO;

public class UniqueUserFilter : IActionFilter
{
    private static HashSet<string> uniqueUsers = new HashSet<string>();
    private static string logPath = "unique_user_log.txt";

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string userIP = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        uniqueUsers.Add(userIP);
        File.WriteAllText(logPath, $"Unique users count: {uniqueUsers.Count}\n");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
