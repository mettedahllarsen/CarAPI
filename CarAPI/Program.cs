using CarAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Singleton - kun en liste, så det er den samme liste lige meget hvad vi arbejder med 

builder.Services.AddSingleton<CarsRepository>(new CarsRepository());


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
