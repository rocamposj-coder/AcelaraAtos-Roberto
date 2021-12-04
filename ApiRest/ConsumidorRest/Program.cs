using ApiRest.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsumidorRest
{
    internal class Program
    {
        
            static List<Aluno> Get()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://localhost:7227/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

                    HttpResponseMessage response = client.GetAsync("api/AlunosBanco/").Result;
                    if (response.IsSuccessStatusCode)
                    {  //GET
                        List<Aluno> listaAlunos = response.Content.ReadAsAsync<List<Aluno>>().Result;
                        return listaAlunos;
                    }
                    
                }

                return null;
            }



        static void Post()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:7227/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
                 
                //POST
                Aluno alu = new Aluno() { Nome = "Aluno do Console", Telefone = "5656-5656" , MensagemErro=""};
                //HttpResponseMessage response =   client.PostAsJsonAsync("api/AlunosBanco/", alu).Result;

                HttpResponseMessage response = client.PostAsJsonAsync("api/AlunosBanco/", alu).Result;


                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var teste =  JsonConvert.DeserializeObject<Aluno>(jsonString);
                }

                Console.WriteLine("Aluno incluído !");
                Console.ReadKey();
                
                
                
                
            }
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
           //var retorno = Get();

            Post();

            Console.WriteLine("Hello World!");
        }
    }
}
