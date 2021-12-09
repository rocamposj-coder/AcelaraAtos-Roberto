using ApiRest.Entidades;

namespace ApiRest.DAO_DAPPER
{
    public interface IDAO_Aluno
    {
        Aluno CadastrarAluno(Aluno alu);

        Aluno RecuperarAluno(Aluno alu);

        IEnumerable<Aluno> RecuperarAlunos();

        Aluno AtualizarAluno(Aluno alu);


        Aluno RemoverAluno(Aluno alu);
        
    }
}
