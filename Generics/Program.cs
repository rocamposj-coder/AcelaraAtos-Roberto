using System;

namespace Generics
{
    public class Generica<T>
    {
        public void Metodo(T objetoTipo)
        {
            Console.WriteLine(objetoTipo.GetType());
            Console.WriteLine(objetoTipo.ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Generica<int> a = new Generica<int>();
            a.Metodo(13);
        }
    }
}
