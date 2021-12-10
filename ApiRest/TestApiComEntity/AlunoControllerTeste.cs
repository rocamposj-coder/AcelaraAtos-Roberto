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

            //var result = await _Client.GetAsync("/api/Aluno");

            var result = _Client.GetAsync("/api/Aluno").GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail();   
            }
            
            var objeto = JsonConvert.DeserializeObject<ResultViewModel<List<Aluno>>>(resultContent);



            Assert.AreNotEqual(0, 0);
        }


    }
}