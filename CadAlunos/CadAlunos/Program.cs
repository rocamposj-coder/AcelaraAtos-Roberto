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
            Console.Clear();
            Console.WriteLine("Digite o nome do Aluno");
            alu.Nome = Console.ReadLine();
            /*
             Leitura dos demais atributos ...
             */
            return alu;
        }

        static char Menu()
        {
            int opcao = 0;
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Para Cadastrar");
            Console.WriteLine("2 - Para Listar");
            Console.WriteLine("0 - Para sair");

            var op = Console.ReadKey();            
            

            return op.KeyChar;
        }

        static void Main(string[] args)
        {
            char opcao = Menu();

            while (opcao != 0)
            {
                switch (opcao)
                {
                    case '0':
                        Console.WriteLine("Saindo ....");
                        break;
                    case '1':
                        Aluno alu = CadastrarAluno();
                        NE_Aluno neAluno = new NE_Aluno();
                        alu = neAluno.CadastrarAluno(alu);

                        if (alu.CodErro == 1)
                            Console.WriteLine($"Aluno {alu.Nome} cadastrado com sucesso !");
                        else
                            Console.WriteLine(alu.MSGErro);

                        break;

                     default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                opcao = Menu();
            }

        }
    }
}
