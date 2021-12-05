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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        [Column("nome", TypeName = "VARCHAR")]
        public String Nome { get; set; }

        [Required]        
        [Column("cargaHoraria", TypeName = "BIGINT")]
        public int CargaHoraria { get; set; }

        [ForeignKey("ProfessorId")]
        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
    }
}
