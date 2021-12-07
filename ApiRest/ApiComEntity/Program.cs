using ApiComEntity.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.
    Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //Não valida mais automaticamente o model state
    });

builder.Services.AddDbContext<TESTEContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();

app.MapControllers();

app.UseSwaggerUI();

app.Run();
