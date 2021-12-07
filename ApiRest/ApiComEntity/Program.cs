using ApiComEntity.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<TESTEContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
