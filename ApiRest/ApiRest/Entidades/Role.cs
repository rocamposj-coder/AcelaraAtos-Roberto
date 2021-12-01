namespace ApiRest.Entidades
{
    public class Role
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int IdUsuario { get; set; }
    }
}
