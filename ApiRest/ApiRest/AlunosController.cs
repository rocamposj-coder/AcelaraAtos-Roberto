using ApiRest.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private List<Aluno> listaAlunos;

        public AlunosController()
        {
            listaAlunos = new List<Aluno>();
            MontarListaAlunos();
        }

        private void MontarListaAlunos()
        {            
            Aluno aluno = new Aluno();
            aluno.Nome = "Hary poter";
            aluno.Telefone = "1111-1111";
            aluno.Id = 13;

            Aluno aluno2 = new Aluno();
            aluno2.Nome = "Mickey Mouse";
            aluno2.Telefone = "2222-2222";
            aluno2.Id = 14;

            Aluno aluno3 = new Aluno();
            aluno3.Nome = "Indiana Jones";
            aluno3.Telefone = "3333-3333";
            aluno3.Id = 15;

            Aluno aluno4 = new Aluno();
            aluno4.Nome = "Vingador Hulk";
            aluno4.Telefone = "4444-4444";
            aluno4.Id = 16;

            listaAlunos.Add(aluno);
            listaAlunos.Add(aluno2);
            listaAlunos.Add(aluno3);
            listaAlunos.Add(aluno4);            
        }


        // GET: api/<AlunosController>
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {            
            return listaAlunos;
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {            
            //Consulta na relação de alunos
            var alu = listaAlunos.FirstOrDefault(a => a.Id == id);            

            return alu;
        }

        // POST api/<AlunosController>
        [HttpPost]  //INSERIR ...
        public IEnumerable<Aluno> Post([FromBody] Aluno value)
        {
            listaAlunos.Add(value);
            return listaAlunos;
        }

        
        // PUT api/<AlunosController>/13 -> Harry
        [HttpPut("{id}")]
        public IEnumerable<Aluno> Put(int id, [FromBody] Aluno value)
        {
            var elementoEncontrado = listaAlunos.Where(a => a.Id == id).First();
            elementoEncontrado.Id = value.Id;
            elementoEncontrado.Nome = value.Nome;

            return listaAlunos;
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
        public IEnumerable<Aluno> Delete(int id)
        {
            var elementoEncontrado = listaAlunos.Where(a => a.Id == id).First();
            listaAlunos.Remove(elementoEncontrado);
            return listaAlunos;
        }
    }
}
