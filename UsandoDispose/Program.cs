using System;

namespace UsandoDispose
{

    interface IPessoa
    {
        string Nome { get; set; }
        string Cpf { get; set; }
        string Telefone { get; set; }
    }

    class Pessoa : IDisposable, IPessoa
    {
        private string nome;
        private string cpf;
        private string telefone;
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }

        

        public Pessoa(string nome)
        {
            Console.WriteLine("Construtor PAI com parametros " + nome);        
        }


        public Pessoa()
        {
            Console.WriteLine("Construtor PAI sem parametros");
        }

        public virtual void Exibir() //Este é o metodo genérico
        {            
            Console.WriteLine($"{Nome} {Cpf} {Telefone}");
        }

        public void Dispose()
        {
            Console.WriteLine("Finalizando o objeto");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa.alo = 10;

           
            using (Pessoa pessoa = new Pessoa("Roberto"))
            {
                
                Console.WriteLine("Executando enquanto o objeto existe");
            }


                //pessoa.Dispose(); //posso me escquecer de chamar

               
        }
    }
}
