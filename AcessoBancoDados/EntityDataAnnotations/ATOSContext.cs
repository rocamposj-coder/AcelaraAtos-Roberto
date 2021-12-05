using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAnnotations
{
    public  class ATOSContext : DbContext
    {
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ATOS;Trusted_Connection=True;Connection Timeout=60;User ID=sa;Password=boi228369");
            optionsBuilder.LogTo(Console.WriteLine); //Para logar as consultas no console
        }
    }
}
