using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace ArquivoTexto
{

    public struct Aluno
    {
        //Propriedades
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }

        //Metodos
        public void Imp()
        {
            Console.WriteLine($"Id = {Id} Nome = {Nome}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arquivos");
            Aluno alu = new Aluno();
            alu.Id = 1;
            alu.Idade = 25;
            alu.Nome = "Ryu";

            Aluno alu2 = new Aluno();
            alu2.Id = 1;
            alu2.Idade = 25;
            alu2.Nome = "Ken";

            Aluno alu3 = new Aluno();
            alu3.Id = 1;
            alu3.Idade = 25;
            alu3.Nome = "Blanka";

            List<Aluno> alunos = new List<Aluno>();
            alunos.Add(alu);
            alunos.Add(alu2);
            alunos.Add(alu3);


            SalvarArquivoTexto("C://NOVO/alunos.txt", alunos);

            List<Aluno> listaRetorno = LerArquivoTexto("C://NOVO/alunos.txt");

        }


        static void SalvarArquivoTexto(string caminho, List<Aluno> listaAlunos)
        {
            StreamWriter sw = new StreamWriter(caminho);
            string jsonString = JsonSerializer.Serialize(listaAlunos);
            sw.Write(jsonString);
            sw.Close();
        }


        static List<Aluno> LerArquivoTexto(string caminho)
        {
            List<Aluno> listaAlunos = new List<Aluno>();
            StreamReader sr = new StreamReader(caminho);
            string json = sr.ReadToEnd();
            listaAlunos = JsonSerializer.Deserialize<List<Aluno>>(json);
            return listaAlunos;
        }
    }
}
