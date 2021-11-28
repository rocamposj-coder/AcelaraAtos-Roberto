var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

/*app.MapGet("/", () => "Alo mundo");

app.MapGet("/{nomeAluno}", (string nomeAluno) =>
    {
        return Results.Ok($"Ola {nomeAluno}");
    });


app.MapPost("/", (Usuario user) =>
    {
        return Results.Ok(user);
    });
*/
app.Run();


public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
}
