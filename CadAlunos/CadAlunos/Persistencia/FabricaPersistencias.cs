using CadAlunos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    
    internal class FabricaPersistencias
    {
        //const int TipoPersistencia = 0;

        public IPersistencia CriarPersistencia()
        {
            IPersistencia persistencia = null;
            if (Configuracao.FlagPersistencia == 0) //Arquivo
            {
                persistencia = new PersistenciaArquivo();
            }
            else if (Configuracao.FlagPersistencia == 1) //Banco
            {
                persistencia = new PersistenciaBanco();
            }
            else
            {
                persistencia = new PersistenciaMock();
            }
            return persistencia;
        }

    }
}
