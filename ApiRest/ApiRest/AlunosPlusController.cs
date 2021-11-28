using ApiRest.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosPlusController : ControllerBase
    {
        private List<Aluno> listaAlunos;

        public AlunosPlusController()
        {
            listaAlunos = new List<Aluno>();
            MontarListaAlunos();
        }

        private void MontarListaAlunos()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = "Hary poter";
            aluno.Id = 13;

            Aluno aluno2 = new Aluno();
            aluno2.Nome = "Mickey Mouse";
            aluno2.Id = 14;

            Aluno aluno3 = new Aluno();
            aluno3.Nome = "Indiana Jones";
            aluno3.Id = 15;

            Aluno aluno4 = new Aluno();
            aluno4.Nome = "Vingador Hulk";
            aluno4.Id = 16;

            listaAlunos.Add(aluno);
            listaAlunos.Add(aluno2);
            listaAlunos.Add(aluno3);
            listaAlunos.Add(aluno4);
        }


        // GET: api/<AlunosController>
        [HttpGet]
        public IActionResult Get()
        {
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
            var alu = listaAlunos.FirstOrDefault(a => a.Id == id);
            if (alu == null)
                return NotFound();
            else
                return Ok(alu);
        }

        // POST api/<AlunosController>
        [HttpPost]  //INSERIR ...
        public IActionResult Post([FromBody] Aluno value)
        {
            listaAlunos.Add(value);
            return  Created($"/{value.Id}",listaAlunos);
        }


        // PUT api/<AlunosController>/13 -> Harry
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno value)
        {
            var elementoEncontrado = listaAlunos.Where(a => a.Id == id).First();
            if (elementoEncontrado == null)
                return NotFound();
            
            elementoEncontrado.Id = value.Id;
            elementoEncontrado.Nome = value.Nome;

            return Ok(listaAlunos);
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
            var elementoEncontrado = listaAlunos.Where(a => a.Id == id).First();
            if (elementoEncontrado == null)
                return NotFound();
            
            listaAlunos.Remove(elementoEncontrado);
            return Ok(listaAlunos);
        }
    }
}
