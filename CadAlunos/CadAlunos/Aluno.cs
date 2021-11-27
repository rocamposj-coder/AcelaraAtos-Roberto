using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunos
{
    public enum SituacaoAluno
    {
        Aprovado = 1,
        Reprovado = 2,
        EmRecuperacao = 3,
        NaoAvaliado = 4
    }

    public class Aluno : EntidadeBase
    {
        private string nome;
        private string cpf;
        private string telefone;
        private DateTime dataRegistro;
        private SituacaoAluno situacao;

        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }

        public DateTime DataRegistro { get => dataRegistro; set => dataRegistro = value; }
        public SituacaoAluno Situacao { get => situacao; set => situacao = value; }


        public Aluno()
        {
            this.DataRegistro = DateTime.Now;
            this.Situacao = SituacaoAluno.NaoAvaliado;
        }
    }
}
