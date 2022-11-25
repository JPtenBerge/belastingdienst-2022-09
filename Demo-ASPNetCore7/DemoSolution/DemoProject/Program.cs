using System.Text.Json.Serialization;
using DemoProject.DataAccess;
using DemoProject.Middleware;
using DemoProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// registreer je alle grote bouwblokken
// dependency injection

builder.Services.AddRazorPages();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // options.SerializerSettings.Converters.Add(new StringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // $id en $ref
});

// builder.Services.AddControllers().AddNewtonsoftJson(options =>
// {
//     // options.SerializerSettings.Converters.Add(new StringEnumConverter());
//     options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects; // $id en $ref
// });

// builder.Services.AddTransient<IPersonRepository, PersonInMemoryRepository>(); // altijd een nieuwe. voordelig qua side effects
builder.Services.AddTransient<IPersonRepository, PersonDbRepository>(); // altijd een nieuwe. voordelig qua side effects
builder.Services.AddTransient<IProfessionRepository, ProfessionDbRepository>(); // altijd een nieuwe. voordelig qua side effects
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

app.MapControllers();

app.MapRazorPages();

app.Run();