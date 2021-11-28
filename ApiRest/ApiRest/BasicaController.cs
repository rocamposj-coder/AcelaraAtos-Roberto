using ApiRest.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest
{
    [Route("api/Basica")]
    [ApiController]
    public class BasicaController : ControllerBase
    {
        // GET: api/Basica
        [HttpGet]
        public IEnumerable<string> Get()
        {
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
