using System;
using System.Collections.Generic;

namespace APIPadroes.Models
{
    public partial class Telefone
    {
        public int Id { get; set; }
        public string NumeroTelefone { get; set; } = null!;
        public long IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; } = null!;
    }
}
