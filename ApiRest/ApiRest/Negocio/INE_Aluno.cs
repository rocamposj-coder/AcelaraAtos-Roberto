using ApiRest.Entidades;

namespace ApiRest.Negocio
{
    public interface INE_Aluno
    {
        Aluno CadastrarAluno(Aluno alu);

        Aluno RecuperarAluno(Aluno alu);

        IEnumerable<Aluno> RecuperarAlunos();

        Aluno AtualizarAluno(Aluno alu);


        Aluno RemoverAluno(Aluno alu);

    }
}
