using ApiRest.Entidades;
using ApiRest.Negocio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosBancoController : ControllerBase
    {
        private NE_Aluno neAluno;
       

        public AlunosBancoController()
        {
             neAluno = new NE_Aluno();       
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Aluno> listaAlunos = neAluno.RecuperarAlunos();

            if(listaAlunos == null)
                return NotFound();
            else
                return Ok(listaAlunos);
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Consulta na relação de alunos
            var alu = neAluno.RecuperarAluno(new Aluno() { Id = id });
            if (alu == null)
                return NotFound();
            else
                return Ok(alu);
        }

        // POST api/<AlunosController>
        [HttpPost]  //INSERIR ...
        public IActionResult Post([FromBody] Aluno value)
        {
            value = neAluno.CadastrarAluno(value);
            
            return  Created($"/{value.Id}", value);
        }


        // PUT api/<AlunosController>/13 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno value)
        {

            value.Id = id;
            value = neAluno.AtualizarAluno(value);
            
            if (value == null)
                return NotFound();
            
            return Ok(value);
        }

        /*
        //ALTERNATIVA DE IMPLEMENTACAO
        [HttpPut("{id:int}")]
        public IEnumerable<Aluno> Put([FromRoute] int id, [FromBody] Aluno value)
        {
            var elementoEncontrado = listaAlunos.Where(a => a.Id == id).First();
            elementoEncontrado.Id = value.Id;
            elementoEncontrado.Nome = value.Nome;

            return listaAlunos;
        }
        */


        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var retorno = neAluno.RemoverAluno(new Aluno() { Id = id});

            return Ok(retorno);
        }
    }
}
