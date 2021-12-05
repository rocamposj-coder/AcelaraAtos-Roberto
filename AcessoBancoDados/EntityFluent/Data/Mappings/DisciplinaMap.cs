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
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            //Mapeando a tabela
            builder.ToTable("Disciplina");

            // Chave Primaria
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            //Demais propriedades
            builder.Property(d => d.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);


            builder.Property(d => d.CargaHoraria)
                .IsRequired()
                .HasColumnName("cargaHoraria")
                .HasColumnType("INT")
                .HasMaxLength(150);

            //Relacionamento
           /*builder.HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasConstraintName("FK_DISCIPLINA_PROFESSOR");
           */
        }
    }
}
