using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambda.Entidades
{
    internal class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Telefone> ListaTelefones { get; set; }

        public Aluno()
        {
            ListaTelefones = new List<Telefone>();  
        }
    }
}
