using System;
using System.Collections.Generic;

namespace ApiComEntity.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Enderecos = new HashSet<Endereco>();
            Telefones = new HashSet<Telefone>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Telefone { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}

