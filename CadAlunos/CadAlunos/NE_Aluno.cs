using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    internal class NE_Aluno
    {
        public int CadastrarAluno(Aluno alu)
        { 
            int resultado = 0;
            FabricaPersistencias fabrica = new FabricaPersistencias();
            IPersistencia ipersistencia = fabrica.CriarPersistencia();
            ipersistencia.CadastrarAluno(alu);
            return resultado;
        }
    }
}
