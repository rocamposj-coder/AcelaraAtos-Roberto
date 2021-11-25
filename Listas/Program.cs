using System;
using System.Collections.Generic;
using System.Linq;

namespace Listas
{
   

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listaInteiros = new List<int>();
            listaInteiros.Add(9);
            listaInteiros.Add(5);
            listaInteiros.Add(4);
            listaInteiros.Add(8);
            listaInteiros.Add(1);
            listaInteiros.Add(2);
            listaInteiros.Add(6);
            listaInteiros.Add(14);
            listaInteiros.Add(13);
            listaInteiros.Add(10);


            Console.WriteLine("Lista");
            foreach (int i in listaInteiros)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("Lista Ordenada");
            listaInteiros.Sort();            
            foreach (int i in listaInteiros)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Lista Filtrada");
            var listaFiltrada = listaInteiros.Where(x => x % 2 == 0).ToList();
            
            foreach (int i in listaFiltrada)
            {
                Console.WriteLine(i);
            }

            //verficando se um elemento existe na lista
            var existe = listaFiltrada.Any(i => i == 3);
            Console.WriteLine(existe);


            //Adicionando uma lista dentro de outra
            List<int> novaLista = new List<int>();
            novaLista.Add(120);
            novaLista.Add(1450);
            novaLista.AddRange(listaInteiros);

            Console.WriteLine("Nova Lista");
            foreach (int i in novaLista)
            {
                Console.WriteLine(i);
            }


            //Removendo elemento ...ou range
            bool removeu = novaLista.Remove(1450);
            Console.WriteLine($"Conseguiu remover? {removeu}");

            Console.WriteLine("Nova Lista, apos remoção");
            foreach (int i in novaLista)
            {
                Console.WriteLine(i);
            }

            //Limpando a lista Clear

        }
    }
}
