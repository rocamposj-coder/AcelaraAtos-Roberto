using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    internal class NE_Aluno
    {
        public Aluno CadastrarAluno(Aluno alu)
        {
            if (alu == null)
            {
                alu.CodErro = -1;
                alu.MSGErro = "Erro aluno nulo não suportado";
            }
            else
            {
                FabricaPersistencias fabrica = new FabricaPersistencias();
                IPersistencia ipersistencia = fabrica.CriarPersistencia();
                alu = ipersistencia.CadastrarAluno(alu);
            }
            return alu;
        }
    }
}
