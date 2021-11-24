using System;

namespace ComparandoObjetos
{

    class Pessoa
    {
        private string Nome { get; set; }

        public Pessoa(string nome)
        {
            this.Nome = nome;
        }


        public static bool operator ==(Pessoa a, Pessoa b)
        {
            if (a.Nome.CompareTo(b.Nome) == 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Pessoa a, Pessoa b)
        {
            if (a.Nome.CompareTo(b.Nome) != 0)
            {
                return true;
            }
            return false;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var pessoaA = new Pessoa("Roberto de Oliveira");
            var pessoaB = new Pessoa("Roberto de Oliveira");
            //A comparação não é feita com base no conteúdo dos objetos e sim na referencia, ou seja se as duas variáveis
            //refereciam a mesma area de memoria. 
            Console.WriteLine(pessoaA == pessoaB); //false (Porque são duas referencias diferentes)
            pessoaB = pessoaA;
            Console.WriteLine(pessoaA == pessoaB); //true (Porque são duas variáveis que guardam referencia ao mesmo objeto)
        }
    }
}

