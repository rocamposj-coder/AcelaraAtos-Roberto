using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    internal class PersistenciaBanco : IPersistencia
    {
        public void CadastrarAluno(Aluno alu)
        {
            Console.WriteLine($"Cadastrando aluno {alu.Nome} no Banco de Dados");
        }
    }
}
