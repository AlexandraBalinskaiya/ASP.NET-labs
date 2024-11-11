using lr9.Models;

var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку контролерів з представленнями
builder.Services.AddControllersWithViews();

// Реєструємо HttpClient і WeatherService
builder.Services.AddHttpClient();
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
