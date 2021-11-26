using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoDapper
{
    //Para facilitar nossa vida e diminuir a quantidade de codigo utilize sempre o mesmo nome dos atributos do banco
    internal class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set;}
        public string Cep { get; set; }
        public string Numero { get; set; }
        public int IdAluno { get; set; }

    }
}
