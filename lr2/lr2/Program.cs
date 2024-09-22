// Завдання 1
/*var builder = WebApplication.CreateBuilder(args);

//  Додаються конфігураційні файли
builder.Configuration.AddJsonFile("companies.json");
builder.Configuration.AddXmlFile("companies.xml");
builder.Configuration.AddIniFile("companies.ini");

var app = builder.Build();

//  Сервіс для аналізу даних про кількість працівників, доход і рік заснування
app.MapGet("/maxEmployees", () =>
{
    var companies = new List<(string Name, int Employees, int Revenue, int Founded)>
    {
        ("Microsoft", int.Parse(builder.Configuration["Microsoft:Employees"]), int.Parse(builder.Configuration["Microsoft:Revenue"]), int.Parse(builder.Configuration["Microsoft:Founded"])),
        ("Apple", int.Parse(builder.Configuration["Apple:Employees"]), int.Parse(builder.Configuration["Apple:Revenue"]), int.Parse(builder.Configuration["Apple:Founded"])),
        ("Google", int.Parse(builder.Configuration["Google:Employees"]), int.Parse(builder.Configuration["Google:Revenue"]), int.Parse(builder.Configuration["Google:Founded"]))
    };

    var companyWithMaxEmployees = companies.OrderByDescending(c => c.Employees).First();

    return $"Company with the most employees: {companyWithMaxEmployees.Name}";
});
*/

//Завдання 2
var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("personal.json");

var app = builder.Build();


app.MapGet("/about", () =>
{
    var name = builder.Configuration["Name"];
    var lastName = builder.Configuration["LastName"];
    var age = builder.Configuration["Age"];
    var group = builder.Configuration["Group"];

    return $"Name: {name}, LastName: {lastName}, Age: {age}, Group: {group}";
});

app.Run();


app.Run();
