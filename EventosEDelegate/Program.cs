using System;

namespace EventosEDelegate
{

    public class Treinamento
    {
        public int Vagas { get; set; }
        private int vagasEmUso = 0;
        //Assinatura do evento... (delegate)
        public event EventHandler TreinamentoLotadoEvent;


        public Treinamento(int vagas)
        {
            Vagas = vagas;
            vagasEmUso = 0;
        }

        public void RegisrarVaga()
        {
            
            if (vagasEmUso >= Vagas)
            {
                //Treinamento lotado
                AoEncherTreinamento(EventArgs.Empty);
            }
            else
            {
                vagasEmUso++;
                Console.WriteLine("Registrado no treinamento com sucesso!");
            }
        }

        

        protected virtual void AoEncherTreinamento(EventArgs e)
        {
            EventHandler handler = TreinamentoLotadoEvent;
            handler?.Invoke(this, e);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Treinamento trienamentoDotNet = new Treinamento(4);
            trienamentoDotNet.TreinamentoLotadoEvent += AoEncherTreinamento;            
            trienamentoDotNet.RegisrarVaga();
            trienamentoDotNet.RegisrarVaga();
            trienamentoDotNet.RegisrarVaga();
            trienamentoDotNet.RegisrarVaga();
            trienamentoDotNet.RegisrarVaga();
            trienamentoDotNet.RegisrarVaga();
            trienamentoDotNet.RegisrarVaga();
        }

        static void AoEncherTreinamento(Object sender, EventArgs e)
        {
            Console.WriteLine("Sala Lotada");
        }       


    }
}
