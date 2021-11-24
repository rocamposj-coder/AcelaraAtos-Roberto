using System;

namespace UsandoStatica
{

    class Aluno
    {
        static public int Num { get; set; }
        public int NumDinamico { get; set; }

        public void Imp()
        {
            Console.WriteLine($"Num: {Num}    NumDinamico: {NumDinamico}");
        }

        public void Altera()
        {
            Num = 45;
            //NumDinamico = 12;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Aluno.Num = 3;
            Aluno alu = new Aluno();
            alu.NumDinamico = 10;
            alu.Imp();

            Aluno alu2 = new Aluno();
            alu2.Altera();
            
            alu.Imp();


        }
    }
}
