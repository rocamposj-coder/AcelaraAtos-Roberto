using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    public class NE_Aluno
    {
        public Aluno CadastrarAluno(Aluno alu)
        {
            if (alu == null)
            {
                alu = new Aluno();
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


        public List<Aluno> ListarAlunos()
        {
            List<Aluno> listaAlunos;

            FabricaPersistencias fabrica = new FabricaPersistencias();
            IPersistencia ipersistencia = fabrica.CriarPersistencia();
            listaAlunos = ipersistencia.ListarAlunos(); 

            return listaAlunos;
        }


    }
}
