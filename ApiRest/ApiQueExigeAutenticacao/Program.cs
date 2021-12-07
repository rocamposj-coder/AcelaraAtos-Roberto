using ApiQueExigeAutenticacao;
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
        ValidateIssuer = false,   
        ValidateAudience = false
    };
});


builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();   //Quem vc é ?
app.UseAuthorization();    //O que vc pode fazer no sistema ?
app.MapControllers();      //mapear todos os controllers

//app.MapGet("/", () => "Hello World!");

app.Run();
