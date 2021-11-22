using System;

namespace OutroProjeto
{

    class Pessoa
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



    }

    class Aluno : Pessoa
    {
        private string[] disiciplinasCursadas;

        public string[] DisiciplinasCursadas
        {
            //get => disiciplinasCursadas;
            get { return disiciplinasCursadas; } //Alternativa para implementar algun controle
            set => disiciplinasCursadas = value;
        }

        public Aluno()
        {
            Console.WriteLine("Construtor Aluno");
        }

        public override void Exibir()
        {
            Console.Write("ALUNO: ");
            base.Exibir();
        }
    }

    class Instrutor : Pessoa
    {
        private string[] disciplinasMinistradas;

        public string[] DisciplinasMinistradas { get => disciplinasMinistradas; set => disciplinasMinistradas = value; }

        public Instrutor(string nome):base(nome)
        {
            
            this.Nome = nome;
            Console.WriteLine("Construtor Instrutor " + nome);
        }

        public override void Exibir()
        {
            Console.Write("INSTR: ");
            base.Exibir();
        }

    }


    internal class Program
    {

        static void Main(string[] args)
        {
            Aluno alu = new Aluno();
            alu.Nome = "Antonio Fagundes";
            alu.Cpf = "000.000.001-91";
            alu.Telefone = "(35) 99998-9899";
            alu.DisiciplinasCursadas = new string[] { "DotNet", "Java", "SQL", "GIT" };
            alu.Exibir();

            Instrutor instrutor = new Instrutor("Leonardo Dicaprio");
            //instrutor.Nome = "Leonardo Dicaprio";
            instrutor.Cpf = "191.000.000-00";
            instrutor.Telefone = "(35) 98888-8999";
            instrutor.DisciplinasMinistradas = new string[] { "DotNet", "Entity Framework", "Xamarin" };
            instrutor.Exibir();


        }
    }
}
