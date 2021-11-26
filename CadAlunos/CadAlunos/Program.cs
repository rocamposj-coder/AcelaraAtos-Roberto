using System;

/*
 É terminantemente proibido usar a classe Console fora da camada de apresentação
 */

namespace CadAlunos
{
    internal class Program
    {
        static public Aluno CadastrarAluno()
        {
            Aluno alu = new Aluno();
            Console.WriteLine("Digite o nome do Aluno");
            alu.Nome = Console.ReadLine();
            /*
             Leitura dos demais atributos ...
             */
            return alu;
        }

        static void Main(string[] args)
        {
            Aluno alu = CadastrarAluno();
            NE_Aluno neAluno = new NE_Aluno();
            neAluno.CadastrarAluno(alu);
        }
    }
}
