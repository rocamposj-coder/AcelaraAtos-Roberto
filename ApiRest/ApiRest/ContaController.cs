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
        [HttpPost ("v1/login")]
        public IActionResult Login([FromServices]TokenService _tokenService )
        {            
            var token = _tokenService.GenerateToken(user: null);

            return Ok (token);  
        }

        [Authorize (Roles = "admin")]
        [HttpGet("v1/usuario")]
        public IActionResult GetUsuario() => Ok(User.Identity.Name);
    }
}
