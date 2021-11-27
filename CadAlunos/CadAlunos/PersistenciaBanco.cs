using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    internal class PersistenciaBanco : IPersistencia
    {
        public Aluno CadastrarAluno(Aluno alu)
        {
            Console.WriteLine($"Cadastrando aluno {alu.Nome} no Banco de Dados");
            return alu; 
        }

        public List<Aluno> ListarAlunos()
        {
            List<Aluno> listaAlunos = new List<Aluno>();

            return listaAlunos;
        }
    }
}
