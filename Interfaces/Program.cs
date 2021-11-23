using System;

namespace Interfaces
{
    interface IPersistencia
    {
        void Salar();
        void Consultar();
    }

    public class Arquivo : IPersistencia
    {
       
    }

    public class Banco : IPersistencia
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPersistencia iPersistencia;
            iPersistencia = new Arquivo(); // = new Banco 
            iPersistencia.Salar();

        }
    }
}
