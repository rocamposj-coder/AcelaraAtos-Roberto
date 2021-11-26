using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoDapper
{
    internal class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set;}
        public string Cep { get; set; }
        public string Numero { get; set; }
        public int IdAluno { get; set; }

    }
}
