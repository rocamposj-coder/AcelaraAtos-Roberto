using EntityDataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFluent.Data.Mappings
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            //Mapeando a tabela
            builder.ToTable("Professor");

            // Chave Primaria
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            //Demais propriedades
            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnName("cpf")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);


            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);


            builder.Property(p => p.DataRegistro)
                .IsRequired()
                .HasColumnName("dataRegistro")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); //FUNÇÂO DO SQL SERVER
              //.HasDefaultValue(DateTime.Now);

            //Relacionamento um para muitos
            /*builder.HasMany(p => p.Disciplinas)
                .WithOne(d => d.Professor)
                .HasConstraintName("FK_PROFESSOR_DISCIPLINA");
           */


            // MUITOS PARA MUITOS
            
            builder
                 .HasMany(p => p.Disciplinas)
                 .WithMany(d => d.Professores)
                 .UsingEntity<Dictionary<string, object>>(
                     "ProfessorDisciplina",
                     prof => prof
                         .HasOne<Disciplina>()
                         .WithMany()
                         .HasForeignKey("DisciplinaId")
                         .HasConstraintName("FK_ProfDisci_ProfessorID")
                         .OnDelete(DeleteBehavior.Cascade),
                     disc => disc
                         .HasOne<Professor>()
                         .WithMany()
                         .HasForeignKey("ProfessorId")
                         .HasConstraintName("FK_ProfDisci_DisciplinaID")
                         .OnDelete(DeleteBehavior.Cascade));
            
            //https://docs.microsoft.com/pt-br/ef/core/saving/cascade-delete
        }
    }
}
