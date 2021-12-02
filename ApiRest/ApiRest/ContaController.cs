using ApiRest.Entidades;
using ApiRest.Negocio;
using ApiRest.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest
{
    //[Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ContaController : ControllerBase
    {
        /*private readonly TokenService _tokenService;
        public ContaController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }*/

        [AllowAnonymous]
        [HttpPost("v1/criarconta")]
        public IActionResult RegistrarUsuario([FromServices] NE_Usuario neUsuario,  [FromBody] Usuario usu)
        {
            usu = neUsuario.CadastrarUsuario(usu);

            if(usu.Id == 0)
                return BadRequest();

            return Created($"/{usu.Id}", usu);
        }


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

       /*
        [Authorize (Roles = "admin")]
        [HttpGet("v1/admin")]
        public IActionResult GetAdmin() => Ok(User.Identity.Name);
        
        
        [Authorize(Roles = "user")]
        [Authorize(Roles = "admin")]
        [HttpGet("v1/usuario")]
        public IActionResult GetUsuario() => Ok(User.Identity.Name);

        [Authorize(Roles = "caochupandomanga")]
        [HttpGet("v1/cao")]
        public IActionResult GetCaoChupandoManga() => Ok(User.Identity.Name);
        */
    }
}
