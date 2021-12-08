using System.ComponentModel.DataAnnotations;

namespace APIPadroes.ViewModel
{
    public class CadastrarAlunoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        //[EmailAddress]
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "O campo telefone deve ter entre 9 e 11 caracteres")]
        public string Telefone { get; set; }
    }
}
