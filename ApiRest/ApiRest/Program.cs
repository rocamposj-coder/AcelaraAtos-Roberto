using ApiRest;
using ApiRest.Negocio;
using ApiRest.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuracao.JwtKey);


//Utilizado para autenticar
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,   //Utilizandos quando estamos trabalhando a autentica��o de varias apis
        ValidateAudience = false
    };
});


builder.Services.AddControllers();


//builder.Services.AddTransient() //Cria novo objeto a cada requisi��o
//builder.Services.AddScoped() // objeto criado por transa��o ( metodos na sequencia das camadas - mesma requisi��o)
//builder.Services.AddScoped() // objeto � unico por app

builder.Services.AddSingleton<NE_Usuario>();
builder.Services.AddTransient<TokenService>(); //Cria novo objeto a cada requisi��o em cada metodo

var app = builder.Build();

 
app.UseAuthentication();   //Quem vc � ?
app.UseAuthorization();    //O que vc pode fazer no sistema ?

app.MapControllers();

/*
app.MapGet("/", () => "Alo mundo");

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

/*
public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
}
*/