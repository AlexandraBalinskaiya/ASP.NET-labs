using Microsoft.Extensions.Configuration;
using lr4.Models; // ϳ��������� �������� ���� � ������� Profile � Book
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// ������������� ����� profiles.json � books.json
builder.Configuration.AddJsonFile("profiles.json");
builder.Configuration.AddJsonFile("books.json");

var app = builder.Build();

app.UseRouting();

// ��������������� � ���������� URL �� ������� /Library
app.MapGet("/", () => Results.Redirect("/Library"));

// �������� ������� Library
app.MapGet("/Library", () => "Welcome to the Library!");

// ������� Library/Profile/{id?}
app.MapGet("/Library/Profile/{id:int?}", (int? id, IConfiguration config) =>
{
    var profiles = config.GetSection("Profiles").Get<List<Profile>>();

    if (id.HasValue && id.Value >= 0 && id.Value <= 5)
    {
        var profile = profiles.FirstOrDefault(p => p.Id == id.Value);
        return profile != null
            ? Results.Text($"ID: {profile.Id}, Name: {profile.Name}, Age: {profile.Age}")
            : Results.NotFound("���������� � ����� ID �� ���������.");
    }
    else if (!id.HasValue)
    {
        var currentUser = profiles.FirstOrDefault(p => p.Id == 0);
        return currentUser != null
            ? Results.Text($"ID: {currentUser.Id}, Name: {currentUser.Name}, Age: {currentUser.Age}")
            : Results.NotFound("���������� ��� ����������� �� ��������.");
    }
    else
    {
        return Results.BadRequest("ID �� ���� ������ �� 0 �� 5.");
    }
});

// ������� Library/Books ��� ��������� ������ ����
app.MapGet("/Library/Books", (IConfiguration config) =>
{
    var books = config.GetSection("Books").Get<List<Book>>();

    if (books == null || !books.Any())
    {
        return Results.NotFound("������ ���� �������.");
    }

    var bookList = string.Join("\n", books.Select(b => $"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}"));
    return Results.Text(bookList);
});

app.Run();
