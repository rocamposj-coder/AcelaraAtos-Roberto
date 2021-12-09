using CadAlunos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class AlunoNeTest
    {
        public AlunoNeTest()
        {
            Configuracao.FlagPersistencia = 3;
        }

        [TestMethod]
        public void Ao_Inserir_Aluno_Nulo()
        {
            NE_Aluno neAluno = new NE_Aluno();
            Aluno alu = null;
            alu = neAluno.CadastrarAluno(alu);
            Assert.AreEqual(-1, alu.CodErro);
        }

        [TestMethod]
        public void Ao_Inserir_Aluno()
        {
            NE_Aluno neAluno = new NE_Aluno();
            Aluno alu = new Aluno() { Nome = "Roberto", Cpf = "098987987987", Telefone = "3333-3333"};
            alu = neAluno.CadastrarAluno(alu);
            Assert.AreEqual(1, alu.CodErro);
        }
    }
}