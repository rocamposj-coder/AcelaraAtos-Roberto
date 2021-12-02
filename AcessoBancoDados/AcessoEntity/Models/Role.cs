using System;
using System.Collections.Generic;

namespace AcessoEntity.Models
{
    public partial class Role
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
