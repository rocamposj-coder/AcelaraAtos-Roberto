using ApiComEntity.Controllers;
using ApiComEntity.Models;
using ApiComEntity.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace TestApiComEntity
{
    [TestClass]
    public class AlunoControllerTeste
    {


        
            
            
            
        


        [TestMethod]
        [TestCategory("Controller")]
        public async Task AoRecuperarAlunos()
        {

            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // ... Configure test services
                });

            var _Client = application.CreateClient();

            

            var result = _Client.GetAsync("/api/Aluno").GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail();   
            }

            Retorno<List<Aluno>> resultViewModel = null;

            try
            {

                resultViewModel = JsonConvert.DeserializeObject<Retorno<List<Aluno>>>(resultContent);

                
            }
            catch(Exception e)
            { 
                string message = e.Message;
            }

            Assert.AreNotEqual(0, resultViewModel?.Data.Count);

        }


    }
}