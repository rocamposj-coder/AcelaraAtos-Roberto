namespace ApiRest.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaCriptografada { get; set; }

        public List<Role> ListaRoles { get; set; }

        public Usuario()
        {
           ListaRoles = new List<Role>();
        }
        
    }
}
