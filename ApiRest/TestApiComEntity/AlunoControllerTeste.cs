using ApiComEntity.Controllers;
using ApiComEntity.Models;
using ApiComEntity.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

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

            var httpResponse = await _Client.GetAsync("/api/Aluno");
                                                              


        Assert.AreNotEqual(0, 0);
        }


    }
}