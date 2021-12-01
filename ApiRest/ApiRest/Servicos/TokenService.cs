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
                    new Claim(ClaimTypes.Name, user.Nome)             //User.Identity.Name
                    //new Claim(ClaimTypes.Role, "admin"),            //User.IsInRole
                    //new Claim(ClaimTypes.Role, "caochupandomanga"), //User.IsInRole
                   
                }),                
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    algorithm:SecurityAlgorithms.HmacSha256Signature)
            };

            foreach(var role in user.ListaRoles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.Descricao));
            }


            //Criando efetivamente o TOKEN
            var token  = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
