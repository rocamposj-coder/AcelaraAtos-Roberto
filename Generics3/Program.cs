using System;

namespace Generics3
{
    public class Generica<T> //É possivel ter mais de um tipo genérico                             
        where T : IPessoa        
    {

        public void Exibir(T entidade)
        {
            Console.WriteLine($"O tipo recebido pelo metodo salvar foi {entidade.GetType()} ");
            entidade.Imprimir();
        }
    }

    public interface IPessoa
    {
        public int Idade { get; set; }
        public string Nome { get; set; }

        void Imprimir();
    }

    public class Instrutor : IPessoa
    {
        public int Idade { get; set; }
        public string Nome { get; set; }

        public void Imprimir()
        {
            Console.WriteLine($"Instrutor Nome: {Nome} idade {Idade}");
        }
    }
    public class Aluno : IPessoa
    {
        public int Idade { get; set; }
        public string Nome { get; set; }

        public void Imprimir()
        {
            Console.WriteLine($"Aluno Nome: {Nome} idade {Idade}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno = new Aluno();
            Instrutor instrutor = new Instrutor();
            

            Generica<IPessoa> a = new Generica<IPessoa>();
            a.Exibir(aluno);
            a.Exibir(instrutor);




        }
    }
}
