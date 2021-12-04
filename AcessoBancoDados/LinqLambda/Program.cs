using LinqLambda.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLambda
{
    internal class Program
    {
        static List<Disciplina> carregarDisciplinas()
        {
            List<Disciplina> lista = new List<Disciplina>();

            Disciplina dis1 = new Disciplina();
            dis1.id = 1;
            dis1.nome = "Plataforma DotNet com C#";
            lista.Add(dis1);

            Disciplina dis2 = new Disciplina();
            dis2.id = 2;
            dis2.nome = "Plataforma Java";
            lista.Add(dis2);

            Disciplina dis3 = new Disciplina();
            dis3.id = 3;
            dis3.nome = "Introdução ao Android";
            lista.Add(dis3);

            Disciplina dis4 = new Disciplina();
            dis4.id = 4;
            dis4.nome = "Introdução ao IOS";
            lista.Add(dis4);

            return lista;

        }

        static List<Aluno> CarregarAlunos()
        { 
            List<Aluno> listaAlunos =   new List<Aluno>();

            for (int i = 0; i < 10; i++)
            { 
                Aluno alu = new Aluno();  
                alu.Id = i;
                alu.Nome = "Nome" + i;
                
                for(int j=0; j<3; j++) 
                {
                    Telefone telefone = new Telefone();
                    telefone.Id = j;
                    telefone.Numero = $"{j}{i}{j}{i}-{j}{i}{j}{i}";
                    telefone.IdAluno = alu.Id;
                    alu.ListaTelefones.Add(telefone);
                }

                listaAlunos.Add(alu);
            }

            return  listaAlunos;
        }

        static List<Clube> carregaClubes()
        {
            List<Clube> listaClubes = new List<Clube>();

            Clube clb = new Clube();
            clb = new Clube(); clb.nome = "Atlético-MG   "; clb.pontos = 81; clb.vitorias = 25; clb.saldo = 33; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Sport         "; clb.pontos = 39; clb.vitorias = 8; clb.saldo = -14; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Santos        "; clb.pontos = 46; clb.vitorias = 11; clb.saldo = -6; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Flamengo      "; clb.pontos = 70; clb.vitorias = 21; clb.saldo = 36; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Bahia         "; clb.pontos = 40; clb.vitorias = 10; clb.saldo = -10; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "São Paulo     "; clb.pontos = 45; clb.vitorias = 10; clb.saldo = -8; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Internacional "; clb.pontos = 48; clb.vitorias = 12; clb.saldo = 4; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Corinthians   "; clb.pontos = 56; clb.vitorias = 15; clb.saldo = 5; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Grêmio        "; clb.pontos = 39; clb.vitorias = 8; clb.saldo = -8; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Fluminense    "; clb.pontos = 45; clb.vitorias = 14; clb.saldo = -1; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Palmeiras     "; clb.pontos = 62; clb.vitorias = 19; clb.saldo = 14; listaClubes.Add(clb);
            clb = new Clube(); clb.nome = "Ceara         "; clb.pontos = 52; clb.vitorias = 15; clb.saldo = -2; listaClubes.Add(clb);





            return listaClubes;
        }

        static void Main(string[] args)
        {

            //Primeiro Exemplo ..
            Console.WriteLine("\n\n Primeiro Exemplo com lambda");
            // Fonte de dados.
            int[] notas = new int[] { 97, 92, 81, 60, 50, 98 };
            // Resultado da consulta lambda.
            foreach (int i in notas.Where(z => z > 80).OrderBy(z => z))
            {
                Console.Write(i + " ");
            }

           


            /**************************************************************************************************/


            //Segundo Exemplo ..
            Console.WriteLine("\n\n Segundo Exemplo com lambda");
            List<Disciplina> listaDis = carregarDisciplinas();

            foreach (Disciplina dis in listaDis.Where(x => x.id >= 2).OrderByDescending(x => x.id))
            {
                Console.WriteLine("ID:" + dis.id + " Nome: " + dis.nome + " ");
            }



            /**************************************************************************************************/

            //Terceiro Exemplo
            Console.WriteLine("\n\n Terceiro Exemplo com lambda"); //So para quebrar uma linha       
            foreach (Disciplina dis in listaDis.Where(x => x.nome.StartsWith("Plata")))
            {
                Console.WriteLine("ID:" + dis.id + " Nome: " + dis.nome + " ");
            }




            /**************************************************************************************************/

            //Quarto Exemplo
            Console.WriteLine("\nQuarto Exemplo com lambda"); //So para quebrar uma linha            
            var listaFiltrada = listaDis.Where(d => d.nome.StartsWith("Plata") && d.id < 2);

            foreach (Disciplina dis in listaFiltrada)
            {
                Console.WriteLine("ID:" + dis.id + " Nome: " + dis.nome + " ");
            }





            /**************************************************************************************************/

            //Quinto Exemplo
            Console.WriteLine("\nQuinto Exemplo com lambda"); //So para quebrar uma linha            
            string[] alimentos = { "arroz", "feijão", "brocolis", "carne", "batata", "beterraba", "banana", "Camarão", "figo" };

            var grupos = alimentos.GroupBy(item => char.ToUpper(item[0]));

            foreach (IGrouping<char, string> ali in grupos)
            {
                Console.WriteLine();
                for (int i = 0; i < ali.Count(); i++)
                {
                    Console.WriteLine("Grupo:" + ali.Key + " Alimento:" + ali.ElementAt(i));
                }
            }

           

            /**************************************************************************************************/

            //Sexto Exemplo
            Console.WriteLine("\nSexto Exemplo com linq"); //So para quebrar uma linha   
            List<int> inteiros = new List<int>();
            inteiros.Add(1);
            inteiros.Add(5);
            inteiros.Add(4);
            inteiros.Add(3);
            inteiros.Add(2);

            var listaSexto = from x in inteiros
                             where x >= 4
                             select x;

            foreach (var item in listaSexto)
            {
                Console.WriteLine(item);
            }




            Console.WriteLine("\n Segunda Parte ... com linq");

            var listaSexto2 = from x in inteiros
                              orderby x descending
                              select x;

            foreach (var item in listaSexto2)
            {
                Console.WriteLine(item);
            }




            /**************************************************************************************************/
            Console.WriteLine("\n Setimo Exemplo ...");

            //Veja este exemplo:
            //Seguindo os critérios de desempate este seria um exemplo ...			
            /*
            Nome         pontos  vitorias  saldo
            Atletico      49 		15 	 	24 	
            São Paulo     42 	 	12 	 	13 	
            Internacional 38 	 	11 	 	9 	
            Corinthians   37 	 	9 	 	12 	
            Grêmio        36 	 	10 	 	4 	
            Fluminense    34 	 	9 	 	13 	
            Atlético-MG   34 	 	9 	 	5 	
            Sport         30 	 	9 	 	17 	
            Santos        30 	 	9 	 	5 	
            Flamengo      30 	 	8 	 	-7 	
            */



            List<Clube> listaClubes = carregaClubes();

            foreach (Clube cb in listaClubes)
            {
                Console.WriteLine(cb.nome + "   " + cb.pontos + "   " + cb.vitorias + "   " + cb.saldo);
            }

            Console.WriteLine("\n segunda Parte");

            //Gostaria de apresentar esta coleção na ordem adequada, seguindo os critérios de desempate.
            //Através de uma consulta Lambda ou Linq ...






            /**************************************************************************************************/
            Console.WriteLine("\n Oitavo Exemplo ...");
            List<Aluno> listaAlunos = CarregarAlunos();

            var query = from alu in listaAlunos
                        where alu.Id >= 4 
                        select alu;

            var lista = query.ToList();



            Console.Read();

        }
    }
}
