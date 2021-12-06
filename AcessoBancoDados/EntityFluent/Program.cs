using EntityDataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFluent
{
    internal class Program
    {
        static void DeletaCriaBanco()
        {
            ATOSContext contexto = new ATOSContext();
            contexto.Database.EnsureDeleted(); //Deleta as tabelas do banco

            contexto.Database.EnsureCreated(); //cria as tabelas no banco
        }

        static void TestandoInseirMuitosParaMuitos()
        {
            ATOSContext contexto = new ATOSContext();

            //Criando uma lista de professores
            List<Professor> listaProfessor = new List<Professor>() {
                new Professor(){ Cpf="00000000000", Nome="Roberto"},
                new Professor(){ Cpf="11111111111", Nome="Sergio"},
                new Professor(){ Cpf="22222222222", Nome="Otavio"}
            };


            var disciplina = new Disciplina()
            {
                CargaHoraria = 60,
                Nome = "Introdução ao C#",
                Professores = listaProfessor
            };


            var disciplina2 = new Disciplina()
            {
                CargaHoraria = 60,
                Nome = "Introdução ao Java",
                Professores = listaProfessor
            };

            contexto.Disciplinas.Add(disciplina);
            contexto.Disciplinas.Add(disciplina2);
            contexto.SaveChanges();

        }

        static void TestandoConsultasBasicas()
        {
            ATOSContext contexto = new ATOSContext();

            var listaProfessores = contexto.Professores.ToList();

            foreach (var prof in listaProfessores)
            { 
                Console.WriteLine($"PROF:{prof.Id} {prof.Nome} {prof.Cpf} {prof.DataRegistro}");
            }


            var listaDisciplinas = contexto.Disciplinas.ToList();

            foreach (var disci in listaDisciplinas)
            {
                Console.WriteLine($"DISCI: {disci.Id} {disci.Nome} {disci.CargaHoraria} ");
            }

        }

        static void TestandoConsultasCompletas()
        {
            ATOSContext contexto = new ATOSContext();

            var listaProfessores = contexto
                            .Professores
                            .Include(p => p.Disciplinas)
                            .ToList();

            foreach (var prof in listaProfessores)
            {
                Console.WriteLine($"PROF:{prof.Id} {prof.Nome} {prof.Cpf} {prof.DataRegistro}");

                var listaDisciplinas = prof.Disciplinas;

                foreach (var disci in listaDisciplinas)
                {
                    Console.WriteLine($"DISCI: {disci.Id} {disci.Nome} {disci.CargaHoraria} ");
                }
            }


            

        }

        static void Main(string[] args)
        {
            DeletaCriaBanco();
            Console.WriteLine("Hello Many to Many !");
        }
    }
}
