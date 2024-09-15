using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var myCompany = new Company
{
    Name = "TechCorp",
    Industry = "Technology",
    NumberOfEmployees = 5000,
    Revenue = 120.5m,
    Headquarters = "Silicon Valley"
};
app.MapGet("/", () => myCompany.ToString());

// Генерація випадкового числа від 1 до 100
//app.MapGet("/", () => new Random().Next(1, 101));

app.Run();


