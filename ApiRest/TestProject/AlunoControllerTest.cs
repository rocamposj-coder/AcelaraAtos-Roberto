using ApiRest;
using ApiRest.Entidades;
using ApiRest.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class AlunoControllerTest
    {
        

        public AlunoControllerTest()
        {
            
        }

        [TestMethod]
        [TestCategory("Controller")]      
        public void AoAcionarGetAluno()
        {
            AlunosController _controller = new AlunosController();

            // Act
            var okResult = _controller.Get().ToList();
            // Assert

            Assert.AreNotEqual(0, okResult.Count);            
        }


        



    }
}