using System.ComponentModel.DataAnnotations;

namespace ApiComEntity.ViewModels
{
    public class EditorAlunoViewModel
    {
        [Required (ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "O Telefone deve ter entre 9 e 11 caracteres")]        
        public string Telefone { get; set; }
    }
}
