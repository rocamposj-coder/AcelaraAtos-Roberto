using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    internal class PersistenciaArquivo : IPersistencia
    {

        public Aluno CadastrarAluno(Aluno alu)
        {
            StreamWriter sw = new StreamWriter("C:\\GITATOS\\Arquivos\\aluno.txt", true);

            sw.WriteLine($"{alu.Nome};{alu.Cpf};{alu.Telefone};{(int)alu.Situacao};{alu.DataRegistro}");
            
            sw.Close();
            return alu;
        }

        public List<Aluno> ListarAlunos()
        { 
            List<Aluno> listaAlunos = new List<Aluno>();

            return listaAlunos;
        }

    }
}
