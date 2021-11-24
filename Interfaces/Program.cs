using System;

namespace Interfaces
{
    interface IPersistencia
    {
        void Salvar();
        void Consultar();        
    }

    /*
    abstract public class APersistencia
    {
        abstract public void Salvar();
        abstract public void Consultar();

        public void Outro()
        { 

        }
    }
    */

    public class Arquivo : IPersistencia
    {
        public void Consultar()
        {
            Console.WriteLine("Consultar no Arquivo");
        }

        public void Salvar()
        {
            Console.WriteLine("Salvar no Arquivo");
        }
    }

    public class Banco : IPersistencia
    {
        public void Consultar()
        {
            Console.WriteLine("Consultar no Banco");
        }

        public void Salvar()
        {
            Console.WriteLine("Salvar no Banco");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPersistencia ip;
            ip = new Arquivo();

            ip.Salvar();
            ip.Consultar();
            

            Arquivo arq = new Arquivo();
            

        }
    }
}
