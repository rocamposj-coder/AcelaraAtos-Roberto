namespace ApiRest.Entidades
{
    public class Aluno : EntidadeBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
