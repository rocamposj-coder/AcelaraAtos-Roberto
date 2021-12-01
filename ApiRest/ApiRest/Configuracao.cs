namespace ApiRest
{
    public static class Configuracao
    {
        //A chave de criptografia que vamos usar
        public static string JwtKey { get; set; } = "sdjkhgHJGJHg3jGJHg5ygfs33tdYtUOy=uyfgf";

        public const string CONNECTION_STRING = "data source=localhost;initial catalog=TESTE;Persist Security Info=True;Connection Timeout=60;User ID=sa;Password=boi228369";
    }

}