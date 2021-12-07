using System;
using System.Collections.Generic;

namespace ApiComEntity.Models
{
    public partial class Endereco
    {
        public long Id { get; set; }
        public string Logradouro { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public long IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; } = null!;
    }
}
