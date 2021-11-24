using System;

namespace Basico
{
    public class Aluno
    {
        public int Num { get; set; }
     
        private int num2;
        public int Num2
        {
            get { return num2; }
            set
            {
                if (value <= 150)
                    num2 = value;
                else
                    Console.WriteLine("Valor Inválido");
            }
        }


        public Aluno()
        {
            this.Num = 10;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Aluno alu;
            alu = new Aluno(); //Construtor
            alu.Num = 13;
            alu.Num2 = 50;
            alu.Num2 = 180;

            Console.WriteLine("Hello World!");

            
        }
    }
}
