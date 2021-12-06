using Microsoft.EntityFrameworkCore;
using System;

namespace EntityDataAnnotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATOSContext context = new ATOSContext();
           
            context.Database.EnsureDeleted();
            context.SaveChanges();           
            
            var sql = context.Database.GenerateCreateScript();

            context.Database.EnsureCreated();            

            Professor prof = new Professor();
            prof.Cpf = "00000000191";
            prof.Nome = "Raimundo Nonato";
            prof.Endereco = "Rua Acacio Flores";
            

            context.Professores.Add(prof);
            context.SaveChanges();
            
        }
    }
}
