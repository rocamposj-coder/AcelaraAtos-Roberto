using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace ArquivoTexto
{

    public struct Externo
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public string[] films { get; set; }
        public string[] species { get; set; }
        public string[] vehicles { get; set; }
        public string[] starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arquivos");
            Externo dadosJson = LerArquivoTexto("C://NOVO/externo.json");

        }

        static Externo LerArquivoTexto(string caminho)
        {
            StreamReader sr = new StreamReader(caminho);
            string json = sr.ReadToEnd();
            Externo objeto = JsonSerializer.Deserialize<Externo>(json);

            Console.WriteLine(objeto.name);

            return objeto;
        }
    }
}
