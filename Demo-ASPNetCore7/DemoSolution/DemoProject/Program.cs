var builder = WebApplication.CreateBuilder(args);

// registreer je alle grote bouwblokken
// dependency injection

builder.Services.AddRazorPages();

var app = builder.Build();

// code hieronder gaat voor iedere request af

app.MapRazorPages();

app.Run();