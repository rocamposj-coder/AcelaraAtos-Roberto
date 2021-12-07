using EntityDataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFluent
{
    internal class Program
    {
        static void DeletaCriaBanco()
        {
            ATOSContext contexto = new ATOSContext();
            contexto.Database.EnsureDeleted(); //Deleta o banco

            contexto.Database.EnsureCreated(); //cria o banco com base nos mapeamentos
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


            var listaDisciplinas = new List<Disciplina>()
            {
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao C#", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Java", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Node", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Angular", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao SQL Server", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Oracle", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao C", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao C++", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Flutter", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Dart", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao Xamarin Forms", Professores = listaProfessor },
               new Disciplina(){ CargaHoraria = 60, Nome = "Introdução ao PHP", Professores = listaProfessor }

            };
        
   

            contexto.Disciplinas.AddRange(listaDisciplinas);
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

                foreach (var disci in prof.Disciplinas)
                {
                    Console.WriteLine($"DISCI: {disci.Id} {disci.Nome} {disci.CargaHoraria} ");
                }
            }


            

        }

        //PAGINAÇÃO
        static List<Disciplina> RecuperarDisicplinas(int skip = 0, int take = 5)
        {
            ATOSContext context = new ATOSContext();
            var listaDisciplinas = context
                .Disciplinas
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();

            return listaDisciplinas;

            /*
            var listaDisciplinas = RecuperarDisicplinas();
            listaDisciplinas = RecuperarDisicplinas(5, 10);
            listaDisciplinas = RecuperarDisicplinas(10);
            */

        }

        //PARALELISMO
        static async Task RecuperaDisciplinas(List<Professor> listaProfessores, List<Disciplina> listaDisciplinas)
        {
            ATOSContext context = new ATOSContext();            
            listaDisciplinas = await context.Disciplinas.ToListAsync();   
            listaProfessores = await context.Professores.ToListAsync();            
        }

        //QUERY MANUAL
        static List<Professor> RecuperarProfessor()
        {
            ATOSContext context = new ATOSContext();
            var listaProfessor = context.Professores.FromSqlRaw("select * from professor").ToList();
            return listaProfessor;
        }

        static void Main(string[] args)
        {
            
             var listaDisciplinas = RecuperarDisicplinas();
             listaDisciplinas = RecuperarDisicplinas(5, 10);
             listaDisciplinas = RecuperarDisicplinas(10);
            

            Console.WriteLine("Hello Many to Many !");
        }
    }
}
