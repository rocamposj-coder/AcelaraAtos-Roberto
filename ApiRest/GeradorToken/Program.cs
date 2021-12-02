using GeradorToken.Negocio;
using GeradorToken.Servicos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSingleton<NE_Usuario>();
builder.Services.AddTransient<TokenService>();

var app = builder.Build();

app.MapControllers();   

app.MapGet("/", () => "Hello World!");

app.Run();
