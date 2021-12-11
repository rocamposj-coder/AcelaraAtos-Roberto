using ApiRest;
using ApiRest.Negocio;
using ApiRest.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Elmah.Io.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureServices(builder);

builder.Services.AddControllers();

var app = builder.Build();
LoadConfiguration(app);

app.UseAuthentication();   //Quem vc é ?
app.UseAuthorization();    //O que vc pode fazer no sistema ?
app.MapControllers();



app.Run();


void LoadConfiguration(WebApplication app)
{
    Configuracao.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Configuracao.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
    Configuracao.ApiKey = app.Configuration.GetValue<string>("ApiKey");
    Configuracao.CONNECTION_STRING = app.Configuration.GetValue<string>("CONNECTION_STRING");

}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    //var key = Encoding.ASCII.GetBytes(Configuracao.JwtKey);
    //var key = Encoding.ASCII.GetBytes(app.Configuration.GetValue<string>("JwtKey"));

    //Utilizado para autenticar
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        var key = Encoding.ASCII.GetBytes(Configuracao.JwtKey);        

        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,   
            ValidateAudience = false
        };
    });

}

void ConfigureServices(WebApplicationBuilder builder)
{    
    builder.Services.AddSingleton<NE_Usuario>();
    builder.Services.AddTransient<TokenService>();

   builder.Services.AddElmahIo(o => {

        o.ApiKey = "4e0e9d6dc0104d37acc5a801e66747fe";
        o.LogId = new Guid("fe71769b-9cd2-45d7-ba19-a89ae8d61410");
    });

}
