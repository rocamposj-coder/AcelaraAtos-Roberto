using ApiRest.DAO_DAPPER;
using ApiRest.Entidades;

namespace ApiRest.Negocio
{
    public class NE_Aluno : INE_Aluno
    {
        private IDAO_Aluno daoAluno;

        public NE_Aluno()
        {
            daoAluno = FabricaDAO.FabricarDAOAluno(); //new DAO_Aluno();
        }

        public Aluno CadastrarAluno(Aluno alu)
        {
            if (alu.Telefone.Count() > 20)
            {
                alu.CodErro = -1;
                alu.MensagemErro = "telefone inválido";
            }
            else
            {
                alu = daoAluno.CadastrarAluno(alu);
            }
            return alu;
        }

        public Aluno RecuperarAluno(Aluno alu)
        {
            alu = daoAluno.RecuperarAluno(alu);
            return alu;
        }

        public IEnumerable<Aluno> RecuperarAlunos()
        {
            IEnumerable<Aluno> listaAlunos;
            listaAlunos = daoAluno.RecuperarAlunos();
            return listaAlunos;
        }

        public Aluno AtualizarAluno(Aluno alu)
        {
            alu = daoAluno.AtualizarAluno(alu);
            return alu;
        }

        public Aluno RemoverAluno(Aluno alu)
        {
            alu = daoAluno.RemoverAluno(alu);
            return alu;
        }



    }
}
