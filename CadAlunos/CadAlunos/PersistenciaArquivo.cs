using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    internal class PersistenciaArquivo : IPersistencia
    {
        public Aluno CadastrarAluno(Aluno alu)
        {
            Console.WriteLine($"Cadastrando aluno {alu.Nome} no Arquivo");
            return alu;
        }
    }
}
