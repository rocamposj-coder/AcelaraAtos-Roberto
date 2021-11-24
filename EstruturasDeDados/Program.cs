﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EstruturasDeDados
{

   

    public class Lista<T> : List<T>
    {
        public override string ToString()
        {
            //StringBuilder stringBuilder = new StringBuilder();
            string retorno = "";

            for(int i=0; i<this.Count; i++)
            {
                retorno += this[i].ToString() + " ";
            }

            return retorno;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estruturas de Dados");

            List<int> listaInteiros = new List<int>();
            listaInteiros.Add(1);
            listaInteiros.Add(2);
            listaInteiros.Add(3);
            Console.WriteLine(listaInteiros);


            Queue<int> filaInteiros = new Queue<int>();
            Console.WriteLine("Enfileirando 1");
            filaInteiros.Enqueue(1);
            Console.WriteLine("Enfileirando 2");
            filaInteiros.Enqueue(2);
            Console.WriteLine("Enfileirando 3");
            filaInteiros.Enqueue(3);
            Console.WriteLine("Enfileirando 4");
            filaInteiros.Enqueue(4);            
            Console.WriteLine($"Quantidade de elementos na fila {filaInteiros.Count}");
            Console.WriteLine("Consumindo a fila");
            var elemento = filaInteiros.Dequeue();
            Console.WriteLine($"Consmuindo elemento {elemento} da fila");
            elemento = filaInteiros.Dequeue();
            Console.WriteLine($"Consmuindo elemento {elemento} da fila");
            elemento = filaInteiros.Dequeue();
            Console.WriteLine($"Consmuindo elemento {elemento} da fila");
            elemento = filaInteiros.Dequeue();
            Console.WriteLine($"Consmuindo elemento {elemento} da fila");
            Console.WriteLine($"Quantidade de elementos na fila {filaInteiros.Count}");
            


            Stack<int> pilhaInteiros = new Stack<int>();
            Console.WriteLine("Empilhando 1");
            pilhaInteiros.Push(1);
            Console.WriteLine("Empilhando 2");
            pilhaInteiros.Push(2);
            Console.WriteLine("Empilhando 3");
            pilhaInteiros.Push(3);
            Console.WriteLine("Empilhando 4");
            pilhaInteiros.Push(4);
            Console.WriteLine(pilhaInteiros);
            Console.WriteLine($"Quantidade de elementos na pilha {pilhaInteiros.Count}");
            Console.WriteLine("Consumindo a Pilha");
            var elem = pilhaInteiros.Pop();
            Console.WriteLine($"Consmuindo elemento {elem} da pilha");
            elem = pilhaInteiros.Pop();
            Console.WriteLine($"Consmuindo elemento {elem} da pilha");
            elem = pilhaInteiros.Pop();
            Console.WriteLine($"Consmuindo elemento {elem} da pilha");
            elem = pilhaInteiros.Pop();
            Console.WriteLine($"Consmuindo elemento {elem} da pilha");
            Console.WriteLine($"Quantidade de elementos na pilha {pilhaInteiros.Count}");

            

        }
    }
}
