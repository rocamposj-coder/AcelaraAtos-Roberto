using System;

namespace EntityDataAnnotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATOSContext context = new ATOSContext();
            

            Professor prof = new Professor();
            prof.Cpf = "00000000191";
            prof.Nome = "Raimundo Nonato";
            

            context.Professores.Add(prof);

            Console.WriteLine("Hello World!");
        }
    }
}
