using DemoProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// registreer je alle grote bouwblokken
// dependency injection

builder.Services.AddRazorPages();

builder.Services.AddTransient<IPersonRepository, PersonInMemoryRepository>(); // altijd een nieuwe. voordelig qua side effects
// builder.Services.AddScoped<>()    // gescoped op basis van het HTTP-request
// builder.Services.AddSingleton<>() // altijd dezelfde. voordelig qua geheugenverbruik

    
    
var app = builder.Build();

// code hieronder gaat voor iedere request af

app.MapRazorPages();

app.Run();