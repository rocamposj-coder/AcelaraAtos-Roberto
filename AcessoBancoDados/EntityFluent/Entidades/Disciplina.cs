using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAnnotations
{
    [Table("Disciplina")]
    public class Disciplina
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public int CargaHoraria { get; set; }

        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
    }
}
