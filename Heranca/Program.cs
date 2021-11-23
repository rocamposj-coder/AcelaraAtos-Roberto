using System;

namespace Heranca
{
    class Pessoa
    {
        public string Nome { get; set; }
        public string Telefone { get; set;}

        public Pessoa()
        {
            Console.WriteLine("Construtor PAI");
        }
        public virtual void Imprimir()
        {
            Console.WriteLine($"Nome : {this.Nome} Telefone: {this.Telefone}");
        }
    }

    class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }

        public PessoaFisica()
        {
            Console.WriteLine("Construtor Pessoa Fisica");
        }

        public override void Imprimir()
        {
            Console.Write($"CPF {this.Cpf} ");
            base.Imprimir();
        }
    }

    class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }

        public PessoaJuridica()
        {
            Console.WriteLine("Construtor Pessoa Juridica");
        }

        public override void Imprimir()
        {
            Console.Write($"CNPJ {this.Cnpj}");
            base.Imprimir();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();   
            PessoaJuridica pessoaJuridica = new PessoaJuridica();
            PessoaFisica pessoaFisica = new PessoaFisica();

            pessoa.Nome = "Pessoa PAI";
            pessoa.Telefone = "4324234323";
            pessoa.Imprimir();  

            pessoaFisica.Nome = "PessoaFisica";
            pessoaFisica.Telefone = "33333333";
            pessoaFisica.Cpf = "121212121212";
            pessoaFisica.Imprimir();
            
        }
    }
}
