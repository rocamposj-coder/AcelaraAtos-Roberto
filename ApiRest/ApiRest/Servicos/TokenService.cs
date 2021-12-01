using ApiRest.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiRest.Servicos
{
    public class TokenService
    {

        public string GenerateToken(Usuario user)
        {
            //Manipulador do TOKEN
            var tokenHandler = new JwtSecurityTokenHandler();
            //Recuperando a chave em um formato de array de bytes
            var key = Encoding.ASCII.GetBytes(Configuracao.JwtKey);
            //As configurações do TOKEN
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "roberto"),  //User.Identity.Name
                    new Claim(ClaimTypes.Role, "admin"),    //User.IsInRole
                    new Claim("Valor", "teste")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    algorithm:SecurityAlgorithms.HmacSha256Signature)
            };

            //Criando efetivamente o TOKEN
            var token  = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
