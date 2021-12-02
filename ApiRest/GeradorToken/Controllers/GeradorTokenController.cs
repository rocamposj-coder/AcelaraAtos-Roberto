using GeradorToken.Entidades;
using GeradorToken.Negocio;
using GeradorToken.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeradorToken
{
    [ApiController]
    public class GeradorTokenController : ControllerBase
    {        
        [AllowAnonymous]
        [HttpPost ("v1/login")]
        public IActionResult Login([FromServices]TokenService _tokenService,
                                   [FromServices] NE_Usuario neUsuario,
                                   [FromBody] Usuario usu )
        {
            bool loginSenhaOK;
            var usuConsulta = neUsuario.VerificarUsuarioSenha(usu, out loginSenhaOK);

            if (loginSenhaOK)
            {
                var token = _tokenService.GenerateToken(usuConsulta);
                return Ok(token);
            }
            else
            { 
                return Unauthorized();
            }            
        }       
    }
}
