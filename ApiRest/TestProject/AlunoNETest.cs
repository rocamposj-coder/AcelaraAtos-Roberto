using ApiRest.Entidades;
using ApiRest.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class AlunoNETest
    {
        public AlunoNETest()
        {
            ApiRest.Configuracao.flagTesteUnitarioDAO = true;
        }

        [TestMethod]
        [TestCategory("Negocio")]      
        public void AoInserirAlunoComDadosCorretos()
        {
            NE_Aluno neAluno = new NE_Aluno();
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
            NE_Aluno neAluno = new NE_Aluno();
            Aluno alu = new Aluno();
            alu.Nome = "Roberto";
            alu.Telefone = "33546ufhfghfghfghfghfghfghfg33-3333";
            alu = neAluno.CadastrarAluno(alu);
            Assert.AreEqual(-1, alu.CodErro);
        }

       

        
    }
}