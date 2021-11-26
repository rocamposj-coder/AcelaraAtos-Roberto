using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoDapper
{
    internal class Aluno
    {
        //Para facilitar nossa vida e diminuir a quantidade de codigo utilize sempre o mesmo nome dos atributos do banco
         
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public List<Telefone> listaTelefones { get; set; }

        public Aluno()
        {
            this.listaTelefones = new List<Telefone>();
        }
    }
}
