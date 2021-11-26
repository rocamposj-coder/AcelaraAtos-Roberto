using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    
    internal class FabricaPersistencias
    {
        const int TipoPersistencia = 1;

        public IPersistencia CriarPersistencia()
        {
            IPersistencia persistencia = null;
            if(TipoPersistencia == 0) //Arquivo
            {
                persistencia = new PersistenciaArquivo();
            }
            else //if(TipoPersistencia == 1) //Banco
            {
                persistencia = new PersistenciaBanco();    
            }

            return persistencia;
        }

    }
}
