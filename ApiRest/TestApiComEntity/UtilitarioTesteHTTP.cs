using ApiComEntity.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestApiComEntity
{
    public static class UtilitarioTesteHTTP<TipoEnvio, TipoRetorno>
    {
        private static HttpClient CriarHttpClient()
        {
            var application = new WebApplicationFactory<Program>()
               .WithWebHostBuilder(builder =>
               {
                   // ... Configure test services
                   builder.ConfigureServices(services =>
                   {                     
                       
                       //services.AddSingleton<IHelloService, MockHelloService>();
                   });
               });

            

            var _Client = application.CreateClient();

            return _Client;
        }

               
        public static async Task<TipoRetorno> HttpPostAsync(TipoEnvio dadosEnvio, string uri, HttpStatusCode statusCodeEsperado) 
        {
            
            var _Client = CriarHttpClient();

            var jsonCorpo = JsonConvert.SerializeObject(dadosEnvio);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonCorpo, Encoding.UTF8, "application/json"),
            };
              
            //SE O CONSUMO PRECISAR ENVIAR O TOKEN
            //_Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

            var response = await _Client.SendAsync(request).ConfigureAwait(false);

            //response.EnsureSuccessStatusCode(); //

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.StatusCode != statusCodeEsperado)
            {
                Assert.Fail();
            }

            TipoRetorno tipoRetorno = JsonConvert.DeserializeObject<TipoRetorno>(responseBody);

            return tipoRetorno;
        }
    }
}
