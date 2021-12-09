namespace ApiRest
{
    public static class Configuracao
    {
        //A chave de criptografia que vamos usar
        public static string JwtKey; // = "sdjkhgHJGJHg3jGJHg5ygfs33tdYtUOy=uyfgf";

        public static string ApiKeyName;// = "api_key";
        public static string ApiKey;// = "acelera_atos_api_hulkesMagA/galo13z0ey8NwCV/ogaloganhoU=";

        public static string CONNECTION_STRING;// = "data source=localhost;initial catalog=TESTE;Persist Security Info=True;Connection Timeout=60;User ID=sa;Password=boi228369";

        public static bool flagTesteUnitarioDAO = false; //Valor padrão não ativa contrução de classes Mock

        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }

        }

    }

}