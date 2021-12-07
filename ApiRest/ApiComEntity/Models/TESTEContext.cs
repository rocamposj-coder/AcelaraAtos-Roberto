using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiComEntity.Models
{
    public partial class TESTEContext : DbContext
    {
        public TESTEContext()
        {
        }

        public TESTEContext(DbContextOptions<TESTEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TESTE;Trusted_Connection=True;Connection Timeout=10;User ID=sa;Password=boi228369");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cep)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cep");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Alunos");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Usuario");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("Telefone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.NumeroTelefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("numeroTelefone");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefone_Alunos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senhacriptografada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senhacriptografada");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
