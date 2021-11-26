using System;

namespace PadraoFabrica
{
    interface Ipersistencia
    {
        void Cadastrar();
    }

    class Arquivo : Ipersistencia
    {
        public void Cadastrar()
        {
            Console.WriteLine("Cadastro no Arquivo");
        }
    }
    class Banco : Ipersistencia
    {
        public void Cadastrar()
        {
            Console.WriteLine("Cadastro no Banco");
        }
    }
    class Memoria : Ipersistencia
    {
        public void Cadastrar()
        {
            Console.WriteLine("Cadastro na Memoria");
        }
    }

    class FabricaPersistencia
    {
        private const int TipoPersistencia = 1; // 0 => Banco e 1 => Arquivo e 2 => Memoria

        static FabricaPersistencia instancia = null;
        private FabricaPersistencia()
        { }
        public static FabricaPersistencia CriaFabrica()
        { 
            if(instancia == null)
                instancia = new FabricaPersistencia();
            return instancia;
        }
        
        public Ipersistencia CriarPersistencia()
        {
            Ipersistencia persitencia = null;

            if (TipoPersistencia == 0)
            {
                persitencia = new Banco();
            }
            else if (TipoPersistencia == 1)
            {
                persitencia = new Arquivo();
            }
            else
            {
                persitencia = new Memoria();
            }

            return persitencia;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            FabricaPersistencia fabrica = FabricaPersistencia.CriaFabrica();
            Ipersistencia persistencia = fabrica.CriarPersistencia();
            persistencia.Cadastrar();


            FabricaPersistencia fabrica2 = FabricaPersistencia.CriaFabrica();
        }
    }
}
