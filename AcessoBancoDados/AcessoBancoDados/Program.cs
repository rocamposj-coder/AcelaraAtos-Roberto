using System;
using System.Collections.Generic;

namespace AcessoBancoDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAOAluno daoAluno = new DAOAluno();
            List<Aluno> listaAlunos = daoAluno.RecuperarAlunos(); // RecuperarAlunosSQLCommand();// RecuperarAlunos();

            Aluno alu = new Aluno();
            alu.Nome = "Atermivaldo";
            alu.Telefone = "3434-1212";

            daoAluno.InserirAlunoParameter(alu);
            
        }
    }
}
