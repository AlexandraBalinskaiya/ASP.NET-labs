using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// Додаємо підтримку сесій
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
=======
>>>>>>> 6c6b3a9b697328b5b0acec3a8941f3ea97708b80
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // Додаємо сесію

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Register}/{id?}");

app.Run();
