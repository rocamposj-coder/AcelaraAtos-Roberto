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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        [Column("nome", TypeName ="VARCHAR")]
        public String Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Column("cpf", TypeName = "VARCHAR")]
        public string Cpf { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Column("endereco", TypeName = "VARCHAR")]
        public string Endereco { get; set; }


    }
}
