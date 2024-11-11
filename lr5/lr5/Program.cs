using Microsoft.Extensions.Logging;
using lr5.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Налаштування Serilog для логування помилок у файл error_log.txt
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.File("logs/error_log.txt")
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Додавання ErrorLoggingMiddleware
app.UseMiddleware<ErrorLoggingMiddleware>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
