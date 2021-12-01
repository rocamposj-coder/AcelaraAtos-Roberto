using ApiRest.DAO_DAPPER;
using ApiRest.Entidades;

namespace ApiRest.Negocio
{
    public class NE_Aluno 
    {
        private DAO_Aluno daoAluno;

        public NE_Aluno()
        {
            daoAluno = new DAO_Aluno();
        }

        public Aluno CadastrarAluno(Aluno alu)
        {
            alu = daoAluno.CadastrarAluno(alu);
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
