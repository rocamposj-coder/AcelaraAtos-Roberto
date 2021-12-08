using ApiComEntity.Extensions;
using APIPadroes.Models;
using APIPadroes.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPadroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {   

        // GET: api/<AlunoController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] TESTEContext context)
        {
            try
            {             
                var listaAlunos = await context.Alunos.ToListAsync();
                if(listaAlunos == null)
                    return NotFound(new RetornoViewModel<Aluno>("Nenhum aluno na base"));

                return Ok(new RetornoViewModel<List<Aluno>>(listaAlunos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<List<Aluno>>("Erro interno."));
            }
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(
                        [FromServices] TESTEContext context,
                        [FromRoute]int id)
        {
            var listaAlunos = await context.Alunos.ToListAsync();
            return Ok(listaAlunos);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(
                       [FromServices] TESTEContext context,
                       [FromBody] CadastrarAlunoViewModel value)
        {

            if (!ModelState.IsValid)
                return BadRequest(new RetornoViewModel<Aluno>(ModelState.RecuperarErros()));

            try
            {
                Aluno aluno = new Aluno()
                {
                    Id = 0,
                    Nome = value.Nome,
                    Telefone = value.Telefone,
                    Enderecos = null,
                    Telefones = null
                };

                await context.Alunos.AddAsync(aluno);
                context.SaveChangesAsync();

                //return Created($"/{aluno.Id}", aluno);
                return Created($"/{aluno.Id}", new RetornoViewModel<Aluno>(aluno));
            }
            catch (DbUpdateException ex)
            {
                //return StatusCode(500, "Falha ao atualizar o registro");
                return StatusCode(500, new RetornoViewModel<List<Aluno>>("Falha ao atualizar o registro"));
            }
            catch (Exception ex)
            {
                //return StatusCode(500, "Erro interno");
                return StatusCode(500, new RetornoViewModel<List<Aluno>>("Erro interno"));
            }


        }


        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
             [FromServices] TESTEContext context,
             [FromRoute]int id,
             [FromBody] Aluno value)
        {

            //Tem que buscar com entity para poder atualizar
            var aluno = await context
                .Alunos
                .FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
                return NotFound();

            aluno.Nome = value.Nome;
            aluno.Telefone = value.Telefone;

            context.Alunos.Update(aluno);
            await context.SaveChangesAsync();

            return Ok(aluno);

        }

        /*
        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
        }
        */
    }
}
