using System;

namespace UsandoUpCastDowncast
{

    class Pessoa
    {
        private string Nome { get; set; }        
        private string Telefone { get; set; }      
    }

    class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }

    }

    class PessoaJuridica : Pessoa
    {
        public string CNPJ { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
           
            //Upcast 
            //Uma pessoa juridica é tambem uma pessoa ! e o contrário é possivel afirmar ?            
            Pessoa pessoa = new Pessoa();
            Pessoa pessoa1 = new PessoaFisica();
            Pessoa pessoa2 = new PessoaJuridica();

            //Downcast
            //uma pessoa juridica não é necessáriamente uma pessoa, então eu tenho que fazer de forma explicita.
            PessoaJuridica pessoaJuridica = (PessoaJuridica)pessoa;
            PessoaFisica pessoaFisica = (PessoaFisica)pessoa;


        }
    }
}

