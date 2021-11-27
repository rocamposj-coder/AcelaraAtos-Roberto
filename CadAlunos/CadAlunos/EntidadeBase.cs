using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    public class EntidadeBase
    {
        public int CodErro { get; set; }
        public string MSGErro { get; set; }

        public EntidadeBase()
        {
            this.CodErro = 1; 
        }
    }
}
