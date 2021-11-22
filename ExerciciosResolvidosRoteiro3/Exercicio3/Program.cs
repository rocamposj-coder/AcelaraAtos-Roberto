using System;
using System.Collections.Generic;

namespace Exercicio3
{


    public enum ESituacaoAprovacao
    {
        Aprovado = 1,
        Reprovado = 2,
        EmRecuperacao = 3
    }

    struct Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Nota { get; set; }
        public ESituacaoAprovacao Situacao { get; set; }
        public DateTime DataRegistro { get; set; }


        public void Imprimir()
        {
            Console.WriteLine($"Nome: {Nome} Idade:{Idade} Nota:{Nota} Situacao:{Situacao} Data Registro:{DataRegistro}");
        }

        public void EntradaAluno()   
        {           
            Console.WriteLine("Digite um nome");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite a idade");
            Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a nota");
            Nota = int.Parse(Console.ReadLine());
            DataRegistro = DateTime.Now;            
        }

    }

    internal class Program
    {
        const int NUM_ALUNOS = 3;
        static Aluno[] listaAlunos = new Aluno[NUM_ALUNOS];

       

        static void EntradaMultiplos()
        {            
            for (int i = 0; i < NUM_ALUNOS; i++)
            {
                listaAlunos[i].EntradaAluno();
            }
        }

        static void ListarTodosAlunos()
        {
            for (int i = 0; i < NUM_ALUNOS; i++)
            {
                listaAlunos[i].Imprimir();
            }
        }

        static double CalcularMedia(out int maiorNota, out int menorNota)
        {
            maiorNota = listaAlunos[0].Nota;
            menorNota = listaAlunos[0].Nota;
            int somaNotas = 0;
            double media;

            for (int i = 0; i < NUM_ALUNOS; i++)
            {
                somaNotas = somaNotas + listaAlunos[i].Nota;

                if (listaAlunos[i].Nota > maiorNota)
                    maiorNota = listaAlunos[i].Nota;

                if (listaAlunos[i].Nota < menorNota)
                    menorNota = listaAlunos[i].Nota;

            }

            media = (double)somaNotas / (double)NUM_ALUNOS;

            return media;
        }


        static void AtualizarStatusAlunos(double media)
        {
            double indiceAprovacao = media + 3;
            double indiceReprovacao = media - 3;

            for (int i = 0; i < NUM_ALUNOS; i++)
            {
                
                if (listaAlunos[i].Nota > indiceAprovacao)
                {
                    listaAlunos[i].Situacao = ESituacaoAprovacao.Aprovado;
                }
                else if (listaAlunos[i].Nota < indiceReprovacao)
                {
                    listaAlunos[i].Situacao = ESituacaoAprovacao.Reprovado;
                }
                else
                {
                    listaAlunos[i].Situacao = ESituacaoAprovacao.EmRecuperacao;
                }
            }
        }

        static int ImprimirMenu()
        {    
            Console.Clear();
            Console.WriteLine("SIS ALUNOS - MENU");
            Console.WriteLine("DIGITE:");
            Console.WriteLine("1 - Para Cadastrar um Aluno");
            Console.WriteLine("2 - Para Cadastrar listar todos alunos");
            Console.WriteLine("3 - Para Calcular a média e atualizar situação dos alunos");
            Console.WriteLine("4 - Pesquisar aluno pelo nome");
            Console.WriteLine("5 - Para sair do programa");
            var opcao = Console.ReadKey();
            var retorno = opcao.KeyChar;
            return Convert.ToInt32(retorno);
        }

        static void Main(string[] args)
        {
            //PRIMEIRA VERSAO
            EntradaMultiplos();
            ListarTodosAlunos();
            int maiorNota, menorNota;
            double media = CalcularMedia(out maiorNota, out menorNota);
            AtualizarStatusAlunos(media);
            ListarTodosAlunos();








            /*
            //SEGUNDA VERSÂO - COM MENU
            int opcao = ImprimirMenu();
            while (opcao != 5)
            { 
                switch(opcao)
                {
                    case 1:
                        Console.WriteLine();
                            break;
                    case 2:
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("Fim programa");                        
                        break;
                }

                opcao = ImprimirMenu();
            }//fim do laço de repetição

            */
        }
    }
}
