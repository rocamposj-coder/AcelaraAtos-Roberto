using System;
using System.Collections.Generic;
using System.Linq;

namespace Listas2
{
    public class Aluno
    {
        private string nome;
        private string cpf;
        private string telefone;
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }


        public override string ToString()
        {
            return $"{Nome} {Cpf} {Telefone}";
        }

        public virtual void Exibir()
        {
            Console.WriteLine($"{Nome} {Cpf} {Telefone}");
        }
    }
    internal class Program
    {

        static void CarregarLista(out List<Aluno> listaAlunos, int tamanho)
        {
            listaAlunos = new List<Aluno>();

            for (int i = 0; i < tamanho; i++) 
            {
                Aluno aluno = new Aluno();
                aluno.Nome = "Nome" + i;
                aluno.Cpf = $"{i}{i}{i}.{i}{i}{i}.{i}{i}{i}-{i}{i}";
                aluno.Telefone = $"({i}{i}) {i}{i}{i}{i}-{i}{i}{i}{i}";
                listaAlunos.Add(aluno);
            }
            
        }

        static void ExibirAlunos(ref List<Aluno> listaAlunos)
        {
            for (int i = 0; i < listaAlunos.Count; i++)
            {
                Console.WriteLine($"CPF: {listaAlunos[i].Cpf} Nome: {listaAlunos[i].Nome} Telefone: {listaAlunos[i].Telefone}");
            }
        }


        static void Main(string[] args)
        {
            List<Aluno> listaAlunos;
            CarregarLista(out listaAlunos, 10);
            Console.WriteLine("Lista Original");
            ExibirAlunos(ref listaAlunos);

            IEnumerable<Aluno> listaFiltrada = listaAlunos.Where(a => a.Nome.Contains('0'));
            var lista = listaFiltrada.ToList(); //Convertendo do tipo IEnumareble para List

            Console.WriteLine("Lista Filtrada");   
            ExibirAlunos(ref lista);


            var reordenada =  listaAlunos.OrderByDescending(a => a.Nome).ToList();
            Console.WriteLine("Lista Reordenada");
            ExibirAlunos(ref reordenada);

            //Covertendo do tipo List para IEnumerable
            IEnumerable<Aluno> ieAlunos = reordenada.AsEnumerable();

        }
    }
}
