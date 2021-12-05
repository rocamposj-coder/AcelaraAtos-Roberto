using EntityDataAnnotations;
using System;

namespace EntityFluent
{
    internal class Program
    {

        

        static void Main(string[] args)
        {
            ATOSContext contexto = new ATOSContext();
            contexto.Database.EnsureDeleted();

            contexto.Database.EnsureCreated();


            //Criando um professor
            Professor professor = new Professor();
            


            Console.WriteLine("Hello Many to Many !");
        }
    }
}
