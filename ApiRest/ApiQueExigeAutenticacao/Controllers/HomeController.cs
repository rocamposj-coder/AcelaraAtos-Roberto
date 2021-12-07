using Microsoft.AspNetCore.Mvc;

namespace ApiQueExigeAutenticacao.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new
            {
                Mensagem = "API Rodando"
            }); 
        }
    }
}
