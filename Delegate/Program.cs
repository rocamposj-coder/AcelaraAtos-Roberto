using System;

namespace ConsoleApplication2
{
    // Declaração do delegate -- define assinatura:
    delegate double DelegateOperacao(double num);


    class Program
    {

        // Metodo regular que implementa a assinatura:
        static double Quadrado(double entrada)
        {
            return entrada * entrada;
        }


        static double Cubo(double entrada)
        {
            return entrada * entrada * entrada;
        }

        static void Main(string[] args)
        {
            // Instancia o delegate com um metodo: (desta forma é possivel passar um método como parametro ..)
            DelegateOperacao ma = Quadrado;
            // Chamando o delegate ma:
            double resultadoQuadrado = ma(4);
            Console.WriteLine("Quadrado: {0}", resultadoQuadrado);


            // Instancia o delegate com um metodo: (desta forma é possivel passar um método como parametro ..)
            ma = Cubo;
            // Chamando o delegate ma:
            double resultadoCubo = ma(2);
            Console.WriteLine("Cubo: {0}", resultadoCubo);


            // Instanciando um delegate com um método anonimo:
            DelegateOperacao ma2 = delegate (double entrada)
            {
                return entrada / entrada;
            };

            double dividido = ma2(5);
            Console.WriteLine("Metodo Anonimo Resultado: {0}", dividido);

            // Instanciado o delegate com expresão lambda.
            DelegateOperacao ma3 = s => s * s * s;
            double cubo = ma3(2);
            Console.WriteLine("Lambda Cubo: {0}", cubo);

            Console.Read();
        }

    }
}