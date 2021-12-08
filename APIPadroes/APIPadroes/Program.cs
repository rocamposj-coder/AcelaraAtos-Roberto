using APIPadroes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TESTEContext>();

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; //Não valida mais automaticamente o model state
    });

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
