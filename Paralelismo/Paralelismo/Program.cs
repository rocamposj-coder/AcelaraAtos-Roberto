using System;
using System.Threading.Tasks;

namespace Paralelismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controle();                       
            Console.WriteLine("Hello World!");
        }

        static void Controle()
        {

            Task[] taskArray = new Task[2];

            taskArray[0] = Task.Factory.StartNew(() => ContadorI());
            taskArray[1] = Task.Factory.StartNew(() => ContadorJ());


            Task.WaitAll(taskArray);

            Console.WriteLine("Tarefas Concluidas !!!");

        }

        static void  ContadorJ()
        {
            for (int j = 0; j < 100000; j++)
            {
                Console.WriteLine("Contator J =" + j);
            }
        }


        static void ContadorI()
        {
            for (int i = 100000; i > 0; i--)
            {
                Console.WriteLine("Contator I =" + i);
            }
        }
    }
}
