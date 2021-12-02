using System;
using System.Collections.Generic;

namespace AcessoEntity.Models
{
    public partial class Endereco
    {
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public long IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
