using System;
using System.Collections.Generic;

namespace AcessoEntity.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Roles = new HashSet<Role>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senhacriptografada { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
