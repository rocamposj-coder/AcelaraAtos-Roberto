
using ApiRest.Entidades;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsumidorAPIRestFlurl
{
    internal class Program
    {

        static List<Aluno> Get()
        {

            string uri = "https://localhost:7227/api/AlunosBanco/";


            List<Aluno> listaAlunos =  uri
                        .WithTimeout(20)
                        //.WithOAuthBearerToken(token)
                        .GetJsonAsync<List<Aluno>>().Result;


            return listaAlunos;
        }



        static void Post()
        {
            string uri = "https://localhost:7227/api/AlunosBanco/";

            //POST
            Aluno alu = new Aluno() { Nome = "Aluno do Console com Flurl", Telefone = "5656-5656", MensagemErro = "" };


                Aluno aluno = uri
                        .WithTimeout(20)
                        //.WithOAuthBearerToken(token)
                        .PostJsonAsync(alu)
                        .ReceiveJson<Aluno>().Result;

            Console.WriteLine("Aluno incluído !");
                Console.ReadKey();




            
        }


        /* 
             //PUT
             response = await client.PutAsJsonAsync("api/AlunosBanco/66", aluNovo);

             //DELETE
             response = await client.DeleteAsync(chaUrl);

         }
         */



        static void Main(string[] args)
        {
           var lista = Get();
               

            Console.WriteLine("Hello World!");
        }
    }
}
