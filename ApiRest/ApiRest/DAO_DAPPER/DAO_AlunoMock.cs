using ApiRest.Entidades;

namespace ApiRest.DAO_DAPPER
{
    public class DAO_AlunoMock : IDAO_Aluno
    {
        public Aluno AtualizarAluno(Aluno alu)
        {
            return alu;
        }

        public Aluno CadastrarAluno(Aluno alu)
        {
            alu.Id = 15;
            return alu;
        }

        public Aluno RecuperarAluno(Aluno alu)
        {
            alu.Nome = "Joselito";
            alu.Telefone = "3333-3333";
            return alu;
        }

        public IEnumerable<Aluno> RecuperarAlunos()
        {
            var listaAlunos = new List<Aluno>();
            listaAlunos.Add(new Aluno { Nome = "Roberto de Oliveira", Telefone = "1111-1111" });
            listaAlunos.Add(new Aluno { Nome = "Hulk Vingador", Telefone = "2222-2222" });
            listaAlunos.Add(new Aluno { Nome = "Homem Arana", Telefone = "3333-3333" });
            listaAlunos.Add(new Aluno { Nome = "Capitão Rever", Telefone = "4444-4444" });
            listaAlunos.Add(new Aluno { Nome = "Joselito", Telefone = "5555-5555" });
            listaAlunos.Add(new Aluno { Nome = "Professor Girafales", Telefone = "6666-6666" });
            listaAlunos.Add(new Aluno { Nome = "Jaiminho o Carteiro", Telefone = "7777-7777" });
            listaAlunos.Add(new Aluno { Nome = "Mestre Yoda", Telefone = "8888-8888" });

            return listaAlunos;
        }

        public Aluno RemoverAluno(Aluno alu)
        {
            alu.Nome = "Roberto de Oliveira";
            alu.Telefone = "1111-1111";
            return alu;
        }
    }
}
