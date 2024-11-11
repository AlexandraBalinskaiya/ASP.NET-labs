using lr3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.UseRouting();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Calc/add?a=5&b=3");
    return Task.CompletedTask;
});

app.MapControllers();
app.Run();
