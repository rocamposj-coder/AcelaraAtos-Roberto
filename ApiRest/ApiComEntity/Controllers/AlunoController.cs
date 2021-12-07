using ApiComEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiComEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        // GET: api/<AlunoController>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] TESTEContext context)
        {
            var listaAlunos = await context.Alunos.ToListAsync();

            return Ok(listaAlunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromServices] TESTEContext context,
                                                  [FromRoute]int id)
        {
            var listaAlunos = await context.Alunos.Where(a => a.Id == id).FirstOrDefaultAsync();

            return Ok(listaAlunos);
        }


        
        // POST api/<AlunoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] TESTEContext context, 
                                              [FromBody] Aluno value)
        {
            await context.Alunos.AddAsync(value);
            await context.SaveChangesAsync();

            return Created($"/{value.Id}", value);   
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromServices] TESTEContext context,
                        [FromRoute] int id,
                        [FromBody] Aluno value)
        {
            //Tem que buscar com entity para poder atualizar
            var aluno = await context
                .Alunos
                .FirstOrDefaultAsync(a => a.Id == id);

            if(aluno == null)
                return NotFound();

            aluno.Nome = value.Nome;
            aluno.Telefone = value.Telefone;

            context.Alunos.Update(aluno);
            await context.SaveChangesAsync();

            return Ok(aluno);

        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] TESTEContext context, 
                                                [FromRoute]int id)
        {
            //Tem que buscar com entity para poder remover
            var aluno = await context
                .Alunos
                .FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
                return NotFound();

            context.Alunos.Remove(aluno);
            await context.SaveChangesAsync();

            return Ok(aluno);

        }

    }
}
