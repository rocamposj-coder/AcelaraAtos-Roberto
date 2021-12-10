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
using System.Text;


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

            Retorno<List<Aluno>> resultViewModel = JsonConvert.DeserializeObject<Retorno<List<Aluno>>>(resultContent);
            Assert.AreNotEqual(0, resultViewModel?.Data.Count);

        }


        [TestMethod]
        [TestCategory("Controller")]
        public async Task AoInserirAluno()
        {

            var application = new WebApplicationFactory<Program>()
               .WithWebHostBuilder(builder =>
               {                   
                    // ... Configure test services
                });

            var _Client = application.CreateClient();

            EditorAlunoViewModel editorAluno = new EditorAlunoViewModel();
            editorAluno.Nome = "Hercules";
            editorAluno.Telefone = "123";

            var jsonCorpo = JsonConvert.SerializeObject(editorAluno);


            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7286/api/Aluno"),
                    Content = new StringContent(jsonCorpo, Encoding.UTF8, "application/json"),
                };

                var response = await _Client.SendAsync(request).ConfigureAwait(false);
                               

                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    Assert.Fail();
                }

                Retorno<Aluno> resultViewModel = JsonConvert.DeserializeObject<Retorno<Aluno>>(responseBody);
                Assert.AreNotEqual(0, resultViewModel?.Erros.Count);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }



        [TestMethod]
        [TestCategory("Controller")]
        public async Task AoInserirAlunoRefatorado()
        {

            EditorAlunoViewModel editorAluno = new EditorAlunoViewModel();
            editorAluno.Nome = "Hercules";
            editorAluno.Telefone = "123";

            try
            {
                string uri = "https://localhost:7286/api/Aluno";
                Retorno<Aluno> retorno = await UtilitarioTesteHTTP<EditorAlunoViewModel, Retorno<Aluno>>.HttpPostAsync(editorAluno, uri, HttpStatusCode.BadRequest);

                Assert.AreNotEqual(0, retorno?.Erros.Count);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }

    }
}