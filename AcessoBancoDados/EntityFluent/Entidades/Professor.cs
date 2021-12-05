using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataAnnotations
{
    [Table("Professor")]
    public class Professor
    {
        public long Id { get; set; }
        
        public String Nome { get; set; }
        
        public string Cpf { get; set; }

        public DateTime DataRegistro { get; set; }
        public List<Disciplina> Disciplinas { get; set; }

       
     }
}
