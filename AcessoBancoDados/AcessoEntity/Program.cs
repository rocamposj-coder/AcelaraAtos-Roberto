using AcessoEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
