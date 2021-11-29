var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();


app.MapGet("/", () =>
{
    return "Hello World!";
});

app.Run();
