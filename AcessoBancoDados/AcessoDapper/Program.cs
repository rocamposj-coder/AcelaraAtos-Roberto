using System;
using System.Collections.Generic;
using System.Linq;


/*
 * 
 Um pouco da hitoria do Dapper
 https://docs.microsoft.com/pt-br/archive/msdn-magazine/2016/may/data-points-dapper-entity-framework-and-hybrid-apps
 

 Repositorio Dapper
  https://github.com/DapperLib/Dapper

Ref:
https://stackoverflow.com/questions/5957774/performing-inserts-and-updates-with-dapper
 */

namespace AcessoDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {

          DAOAluno daoAluno = new DAOAluno();


            var alunoCompleto = daoAluno.RecuperarAlunoEndereco(new Aluno { Id = 63 });



          List<Aluno> listaAluno  = new List<Aluno>() 
          { 
           new Aluno() { Id = 44},
           new Aluno() { Id = 45}
          };            
          
          listaAluno = daoAluno.RecuperarAlunosCompletos(listaAluno);
          


                     

          
            

            //Basica
            List<Aluno> listaAlunos = daoAluno.RecuperarAlunos();// RecuperarAlunos();
            //Com join
            listaAlunos = daoAluno.RecuperarAlunosEndereco();
            listaAlunos = daoAluno.RecuperarAlunosTelefones();
            //Dois Joins
            listaAlunos = daoAluno.RecuperarAlunosTelefonesEndereco();




            //INserindo alunos
            Aluno alu = new Aluno();
            alu.Nome = "Hulk Esmaga";
            alu.Telefone = "4545-4545";

            var listaTelefone = new List<Telefone>
                        {
                            { new Telefone { NumeroTelefone  = "4444-4444" } },
                            { new Telefone { NumeroTelefone  = "5555-5555" } },
                            { new Telefone { NumeroTelefone  = "6666-6666" } }

                        };

            alu.listaTelefones = listaTelefone;


            alu.Endereco = new Endereco()
            {
                Logradouro = "Rua Cidade do Galo",
                Cep = "30.023-90",
                Numero = "123"
            };

            //alu = daoAluno.InserirAluno(alu);

            //alu = daoAluno.InserirAlunoTelefone(alu);

            alu = daoAluno.InserirAlunoTelefoneEndereco(alu);


            alu.Nome = "Roberto Mais que Lindo";
            alu.Telefone = "666 outro tapa na oreia";

            alu = daoAluno.AtualizarAluno(alu);

            var linhas = daoAluno.ExecutarProcedureRemoveAluno(alu);

            var telefones = daoAluno.ExecutarProcedureConsultaTelefones(alu);

            
            

        }
    }
}
