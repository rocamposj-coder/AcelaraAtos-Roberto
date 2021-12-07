﻿using ApiComEntity.Models;
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
                var listaAlunos = await context.Alunos.Where(a => a.Id == id).FirstOrDefaultAsync();
                return Ok(listaAlunos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno.");
            }
        }
    



    // POST api/<AlunoController>
    [HttpPost]
    public async Task<IActionResult> Post([FromServices] TESTEContext context,
                                          [FromBody] EditorAlunoViewModel value)
    {
            if(!ModelState.IsValid)
                return BadRequest();

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

            return Created($"/{aluno.Id}", aluno);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "Falha ao inserir o aluno.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno.");
        }
    }

    // PUT api/<AlunoController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromServices] TESTEContext context,
                    [FromRoute] int id,
                    [FromBody] EditorAlunoViewModel value)
    {

        try
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
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "Falha ao atualizar o aluno.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno.");
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
                    return NotFound();

                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                return Ok(aluno);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Falha ao remover o aluno.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno.");
            }
        }

}
}
