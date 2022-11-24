using DemoProject.DataAccess;
using DemoProject.Middleware;
using DemoProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// registreer je alle grote bouwblokken
// dependency injection

builder.Services.AddRazorPages();

// builder.Services.AddTransient<IPersonRepository, PersonInMemoryRepository>(); // altijd een nieuwe. voordelig qua side effects
builder.Services.AddTransient<IPersonRepository, PersonDbRepository>(); // altijd een nieuwe. voordelig qua side effects
builder.Services.AddTransient<ExceptionLoggingMiddleware>();

// builder.Services.AddScoped<>()    // gescoped op basis van het HTTP-request
// builder.Services.AddSingleton<>() // altijd dezelfde. voordelig qua geheugenverbruik

builder.Services.AddDbContext<PeopleContext>(options =>
{
    options.UseSqlServer("Server=.; Database=peopledb; Integrated Security=true; trustServerCertificate=true");
});

var app = builder.Build();

// code hieronder gaat voor iedere request af

app.UseDeveloperExceptionPage();

app.UseExceptionLoggingMiddleware();

app.UseStaticFiles(); // wwwroot

app.MapRazorPages();

app.Run();