using AcessoEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcessoEntity
{
    internal class Program
    {

        static void TransacaoAlunoEndereco()
        {
            var contexto = new TESTEContext();
            using var transaction = contexto.Database.BeginTransaction();

            try
            {
                //INSERIR
                Aluno aluno = new Aluno()
                {
                    Id = 0,
                    Nome = "Adamastor ",
                    Telefone = "3434-3434"
                };

                aluno.Enderecos = new List<Endereco>();
                aluno.Enderecos.Add(new Endereco() { Logradouro = "Rua Oito", Cep = "32341-070", Numero = "213" });


                contexto.Alunos.Add(aluno);
                contexto.SaveChanges();


                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }

        static void InserirAlunoEndereco()
        {
            var contexto = new TESTEContext();
            //INSERIR
            Aluno aluno = new Aluno()
            {
                Id = 0,
                Nome = "Adamastor ",
                Telefone = "3434-3434"
            };

            aluno.Enderecos = new List<Endereco>();
            aluno.Enderecos.Add(new Endereco() { Logradouro = "Rua Oito", Cep = "32341-070", Numero = "213" });


            contexto.Alunos.Add(aluno);
            contexto.SaveChanges();
        }

        static void Main(string[] args)
        {
            var context = new TESTEContext();

            //var listaAlunos = context.Alunos.ToList();


            var listaAlunos = context.Alunos
                        .Include(a => a.Telefones.Where(t=>t.Id == 94))
                        .Include(a => a.Enderecos)
                        .ToList();

     
            var listaTels = context.Telefones.Where(t => t.Id == 94)
                                .Include(t => t.IdAlunoNavigation)
                                .ToList();

            var query1 = from alu in context.Alunos
                         join tel in context.Telefones on alu.Id equals tel.IdAluno
                         where tel.Id == 94 
                         select alu;

            var lista2 = query1.ToList();


          



            var aluno = new Aluno();
            aluno.Nome = "Napoleao Bonaparte";
            aluno.Enderecos = new List<Endereco>()
            {
                new Endereco() { Logradouro = "Rua Nove", Cep="32341-070", Numero="345"  }
            };
            aluno.Telefones = new List<Telefone>()
            {
                new Telefone () {NumeroTelefone = "2222-22222"  },
                new Telefone () {NumeroTelefone = "3333-33333"  }
            };

            context.Alunos.Add(aluno);
            context.SaveChanges();



            foreach (var item in listaAlunos)
            {
                Console.WriteLine($"{item.Nome} {item.Id} {item.Telefone}");

                foreach (var endereco in item.Enderecos)
                {
                    Console.WriteLine($"ENDERECO: {endereco.Logradouro} {endereco.Cep} {endereco.Numero}");
                }

                foreach (var telefone in item.Telefones)
                {
                    Console.WriteLine($"Telefone: {telefone.NumeroTelefone}");
                }

            }


            Console.WriteLine("Hello World!");
        }
    }
}
