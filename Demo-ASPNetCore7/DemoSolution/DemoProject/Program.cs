using System.Text.Json.Serialization;
using Demo.Shared.Entities;
using DemoProject.DataAccess;
using DemoProject.Hubs;
using DemoProject.Middleware;
using DemoProject.Models;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// registreer je alle grote bouwblokken
// dependency injection

builder.Services.AddIdentity<ScratchUser, IdentityRole>().AddEntityFrameworkStores<PeopleContext>();

builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // options.SerializerSettings.Converters.Add(new StringEnumConverter());
    // options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // $id en $ref
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("blazorfrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7015").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
    });
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

app.UseCors("blazorfrontend"); // stuurt access-origin header terug

app.UseStaticFiles(); // wwwroot

app.UseAuthentication(); // leest de auth cookie uit

app.MapHub<ChatHub>("/chatHub");

app.MapControllers();

app.MapRazorPages();

app.Run();