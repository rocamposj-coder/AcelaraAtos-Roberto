using ApiRest.Atributos;
using ApiRest.Entidades;
using Elmah.Io.Client;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest
{
    [Route("api/Basica")]
    [ApiController]
    public class BasicaController : ControllerBase
    {

        // GET: api/Basica
        
        [ApiKey]
        [HttpGet]
        public IEnumerable<string> Get()
        {

            //throw new Exception("Erro aqui");
            var logger = ElmahioAPI.Create("4e0e9d6dc0104d37acc5a801e66747fe");
            var logId = new Guid("fe71769b-9cd2-45d7-ba19-a89ae8d61410");
            logger.Messages.Fatal(logId, new ApplicationException("Um erro fatal de teste"), "Erro Fatal mensagem");
            logger.Messages.Error(logId, new ApplicationException("Uma exception"), "Error message");
            logger.Messages.Warning(logId, "Um alerta - fica ligado");
            logger.Messages.Information(logId, "Uma mensagem de informação");
            logger.Messages.Debug(logId, "Informação de debug");
            logger.Messages.Verbose(logId, "A verbose message");

            return new string[] { "value1", "value2" };
        }

        // GET api/Basica/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Basica
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var alu  = value;
        }

        // PUT api/Basica/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var param = id;
            var texto = value;
        }

        // DELETE api/Basica/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
