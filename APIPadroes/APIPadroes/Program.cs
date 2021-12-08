using APIPadroes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TESTEContext>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
