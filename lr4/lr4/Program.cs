using Microsoft.Extensions.Configuration;
using lr4.Models; // Підключення простору імен з класами Profile і Book
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Конфігураційні файли profiles.json і books.json
builder.Configuration.AddJsonFile("profiles.json");
builder.Configuration.AddJsonFile("books.json");

var app = builder.Build();

app.UseRouting();

// Перенаправлення з кореневого URL на маршрут /Library
app.MapGet("/", () => Results.Redirect("/Library"));

// Основний маршрут Library
app.MapGet("/Library", () => "Welcome to the Library!");

// Маршрут Library/Profile/{id?}
app.MapGet("/Library/Profile/{id:int?}", (int? id, IConfiguration config) =>
{
    var profiles = config.GetSection("Profiles").Get<List<Profile>>();

    if (id.HasValue && id.Value >= 0 && id.Value <= 5)
    {
        var profile = profiles.FirstOrDefault(p => p.Id == id.Value);
        return profile != null
            ? Results.Text($"ID: {profile.Id}, Name: {profile.Name}, Age: {profile.Age}")
            : Results.NotFound("Користувач з таким ID не знайдений.");
    }
    else if (!id.HasValue)
    {
        var currentUser = profiles.FirstOrDefault(p => p.Id == 0);
        return currentUser != null
            ? Results.Text($"ID: {currentUser.Id}, Name: {currentUser.Name}, Age: {currentUser.Age}")
            : Results.NotFound("Інформація про користувача не знайдена.");
    }
    else
    {
        return Results.BadRequest("ID має бути числом від 0 до 5.");
    }
});

// Маршрут Library/Books для виведення списку книг
app.MapGet("/Library/Books", (IConfiguration config) =>
{
    var books = config.GetSection("Books").Get<List<Book>>();

    if (books == null || !books.Any())
    {
        return Results.NotFound("Список книг порожній.");
    }

    var bookList = string.Join("\n", books.Select(b => $"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}"));
    return Results.Text(bookList);
});

app.Run();
