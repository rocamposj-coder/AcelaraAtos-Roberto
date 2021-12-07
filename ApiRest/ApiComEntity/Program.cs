using ApiComEntity.Models;

var builder = WebApplication.CreateBuilder(args);


builder.
    Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //N�o valida mais automaticamente o model state
    });

builder.Services.AddDbContext<TESTEContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
