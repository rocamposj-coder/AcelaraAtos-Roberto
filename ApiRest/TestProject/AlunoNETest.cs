using ApiRest.Entidades;
using ApiRest.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class AlunoNETest
    {
        protected NE_Aluno neAluno;

        public AlunoNETest()
        {
            ApiRest.Configuracao.flagTesteUnitarioDAO = true;
            neAluno = new NE_Aluno();
        }

        [TestMethod]
        [TestCategory("Negocio")]      
        public void AoInserirAlunoComDadosCorretos()
        {            
            Aluno alu = new Aluno();
            alu.Nome = "Roberto";
            alu.Telefone = "3333-3333";
            alu = neAluno.CadastrarAluno(alu);
            Assert.AreEqual(0, alu.CodErro);
        }


        [TestMethod]
        [TestCategory("Dominio")]
        public void AoInserirAlunoComTelefoneIncorretos()
        {           
            Aluno alu = new Aluno();
            alu.Nome = "Roberto";
            alu.Telefone = "33546ufhfghfghfghfghfghfghfg33-3333";
            alu = neAluno.CadastrarAluno(alu);
            Assert.AreEqual(-1, alu.CodErro);
        }

       

        
    }
}