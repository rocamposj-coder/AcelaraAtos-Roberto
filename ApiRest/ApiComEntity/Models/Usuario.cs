using System;
using System.Collections.Generic;

namespace ApiComEntity.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Roles = new HashSet<Role>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senhacriptografada { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
    }
}
