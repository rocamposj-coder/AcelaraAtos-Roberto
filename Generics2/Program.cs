using System;

namespace Generics2
{
    public class Generica<T> //É possivel ter mais de um tipo genérico                             
    {

        public void Salvar(T entidade)
        {
            Console.WriteLine($"O tipo recebido pelo metodo salvar foi {entidade.GetType()} ");
        }        
    }

    public class Pessoa { }
    public class Treinamento { }

    public class Pagamento { }

    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();   
            Treinamento treinamento = new Treinamento();
            Pagamento pagamento = new Pagamento();

            Generica<Pessoa> a = new Generica<Pessoa>();
            a.Salvar(pessoa);

            Generica<Treinamento> t = new Generica<Treinamento>();
            t.Salvar(treinamento);

        }
    }
}
