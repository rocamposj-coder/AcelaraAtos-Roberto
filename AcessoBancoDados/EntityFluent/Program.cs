using EntityDataAnnotations;
using System;
using System.Collections.Generic;

namespace EntityFluent
{
    internal class Program
    {

        static void TestandoMuitosParaMuitos()
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



        static void Main(string[] args)
        {
            ATOSContext contexto = new ATOSContext();
            contexto.Database.EnsureDeleted(); //Deleta as tabelas do banco

            contexto.Database.EnsureCreated(); //cria as tabelas no banco

            Console.WriteLine("Hello Many to Many !");
        }
    }
}
