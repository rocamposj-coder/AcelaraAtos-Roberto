using System;
using System.Collections.Generic;


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
            //List<Aluno> listaAlunos = daoAluno.RecuperarAlunos();// RecuperarAlunos();

            Aluno alu = new Aluno();
            alu.Nome = "Hulk Esmaga";
            alu.Telefone = "3434-1212";


            var listaTelefone = new List<Telefone>
                        {
                            { new Telefone { NumeroTelefone  = "1233-1234" } },
                            { new Telefone { NumeroTelefone  = "4321-1234" } },
                            { new Telefone { NumeroTelefone  = "5678-1234" } }

                        };

            alu.listaTelefones = listaTelefone;


            alu.Endereco = new Endereco()
            {
                Logradouro = "Rua Cidade do Galo",
                Cep = "30.023-90",
                Numero = "123"
            };



            alu = daoAluno.InserirAlunoTelefoneEndereco(alu);


            //alu.Nome = "Roberto lindo";
            //alu.Telefone = "666um tapa na oreia";

            //alu = daoAluno.AtualizarAluno(alu);

            //listaAlunos = daoAluno.RecuperarAlunosEnderecos();

            //listaAlunos = daoAluno.RecuperarAlunosTelefones();


            var listaAlunos = daoAluno.RecuperarAlunosTelefonesEndereco();

            //daoAluno.ExecutarProcedureConsultaTelefones(alu);

            //alu.IdAluno = 27;
            //daoAluno.ExecutarProcedureRemoveAluno(alu);



        }
    }
}
