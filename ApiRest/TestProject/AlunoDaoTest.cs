using ApiRest.DAO_DAPPER;
using ApiRest.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class AlunoDaoTest
    {

        public AlunoDaoTest()
        {
            ApiRest.Configuracao.flagTesteUnitarioDAO = true;
        }

        [TestMethod]
        [TestCategory("DAO")]
        public void TesteRecuperarAlunos()
        {
            IDAO_Aluno daoAluno  = FabricaDAO.FabricarDAOAluno();
            var lista = daoAluno.RecuperarAlunos().ToList();

            Assert.AreEqual(8, lista.Count);
        }

        [TestMethod]
        [TestCategory("DAO")]
        public void TesteRecuperarUmAluno()
        {
            Aluno alu = new Aluno();
            IDAO_Aluno daoAluno = FabricaDAO.FabricarDAOAluno();
            var alunoConsultado = daoAluno.RecuperarAluno(alu);

            Assert.AreEqual("Joselito", alunoConsultado.Nome);
        }

        /*
        [TestMethod]
        [TestCategory("DAO")]
        public void TesteInserirAluno()
        {
            Assert.Fail();
        }


        [TestMethod]
        [TestCategory("DAO")]
        public void TesteAtualizarAluno()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("DAO")]
        public void DeletarAluno()
        {
            Assert.Fail();
        }
        */
        
    }
}