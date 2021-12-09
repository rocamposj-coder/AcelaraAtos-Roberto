using ApiComEntity.Extensions;
using ApiComEntity.Models;
using ApiComEntity.ViewModels;
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
        /// <summary>
        /// Recupera uma lista de Alunos
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] TESTEContext context)
        {
            try
            {
                var listaAlunos = await context.Alunos.ToListAsync();
                return Ok(new ResultViewModel<List<Aluno>>(listaAlunos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<List<Aluno>>("01x01 Erro interno."));
            }
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromServices] TESTEContext context,
                                                  [FromRoute] int id)
        {
            try
            {
                var aluno = await context.Alunos.Where(a => a.Id == id).FirstOrDefaultAsync();
                if (aluno == null)
                    return NotFound(new ResultViewModel<Aluno>("Conteudo não encontrado."));

                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro interno."));
            }
        }




        // POST api/<AlunoController>
        /// <summary>
        /// Cadastra um Aluno.
        /// </summary>
        /// <param name="EditorAlunoViewModel"></param>
        /// <returns>O novo aluno cadastrado</returns>
        /// <remarks>
        /// Chamada Exemplo:
        ///
        ///     POST /Aluno
        ///     {    
        ///       "nome": "Raimundo NoNato",
        ///       "telefone":"3434-3434"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna o novo aluno cadastrado</response>
        /// <response code="400">Se o retorno é null</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] TESTEContext context,
                                                  [FromBody] EditorAlunoViewModel value)
        {
            /*if(!ModelState.IsValid)
                return BadRequest(ModelState.Values);*/

            //Metodo de extenção
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Aluno>(ModelState.RecuperarErros()));

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
                await context.SaveChangesAsync();

                return Created($"/{aluno.Id}", new ResultViewModel<Aluno>(aluno));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Falha ao inserir o aluno."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro interno."));
            }
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromServices] TESTEContext context,
                        [FromRoute] int id,
                        [FromBody] EditorAlunoViewModel value)
        {
            //Metodo de extenção
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Aluno>(ModelState.RecuperarErros()));

            try
            {

                //Tem que buscar com entity para poder atualizar
                var aluno = await context
                    .Alunos
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (aluno == null)
                    return NotFound(new ResultViewModel<Aluno>("Conteudo não encontrado."));

                aluno.Nome = value.Nome;
                aluno.Telefone = value.Telefone;

                context.Alunos.Update(aluno);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Falha ao atualizar o aluno."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro interno."));
            }

        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] TESTEContext context,
                                                [FromRoute] int id)
        {

            try
            {
                //Tem que buscar com entity para poder remover
                var aluno = await context
                    .Alunos
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (aluno == null)
                    return NotFound(new ResultViewModel<Aluno>("Conteudo não encontrado."));

                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Falha ao remover o aluno."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("Erro interno."));
            }
        }

    }
}
