using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos.Persistencia
{
    internal class PersistenciaMock : IPersistencia
    {
        public Aluno CadastrarAluno(Aluno alu)
        {
            return alu; //Não faz nada
        }

        public List<Aluno> ListarAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();
            alunos.Add(new Aluno() { Nome = "Roberto", Telefone="3333-4444", Cpf ="11111111"  });
            alunos.Add(new Aluno() { Nome = "Josef", Telefone = "3333-4444", Cpf = "11111111" });
            alunos.Add(new Aluno() { Nome = "Indiana Jones", Telefone = "3333-4444", Cpf = "11111111" });

            return alunos;
        }
    }
}
