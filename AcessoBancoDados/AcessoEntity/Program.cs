using AcessoEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcessoEntity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new TESTEContext();

            //var listaAlunos = context.Alunos.ToList();


            var listaAlunos = context.Alunos
                        .Include(a => a.Telefones)
                        .Include(a => a.Enderecos)
                        .ToList();



            var aluno = new Aluno();
            aluno.Nome = "Napoleao Bonaparte";
            aluno.Enderecos = new List<Endereco>() 
            { 
                new Endereco() { Logradouro = "Rua Oito", Cep="32341-070", Numero="345"  }                
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

                foreach(var endereco in item.Enderecos)
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
