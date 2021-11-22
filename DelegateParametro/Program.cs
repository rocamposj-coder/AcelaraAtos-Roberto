using System;

namespace DelegateParametro
{
    // Declaração do delegate -- define assinatura:
    delegate int Operacao(int x, int y);


    class Program
    {

        // Metodo regular que implementa a assinatura:
        static int Soma(int w, int z)
        {
            Console.WriteLine("Somando...");
            return w + z;
        }

        // Metodo regular que implementa a assinatura:
        static int Subtracao(int w, int z)
        {
            Console.WriteLine("Subtraindo...");
            return w - z;
        }

        static int funcao(Operacao op, int a, int b)
        {
            return op(a, b);
        }

        static void Main(string[] args)
        {
            // Instancia o delegate com um metodo: (desta forma é possivel passar um método como parametro ..)
            Operacao op = Subtracao;

            // Chamando o delegate ma:
            int resposta = funcao(op, 3, 4);
            Console.WriteLine("Resultado: {0}", resposta);


            // Instancia o delegate com um metodo: (desta forma é possivel passar um método como parametro ..)
            Operacao op2 = Soma;

            // Chamando o delegate ma:
            int resposta2 = funcao(op2, 3, 4);
            Console.WriteLine("Resultado: {0}", resposta2);


            Console.Read();
        }

    }
}
