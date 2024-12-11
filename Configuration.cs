namespace ProjetoVendasAPI;

public static class Configuration
{
    public static string JwtKey = "dhaun2y28D8SA>SADDSA2323DSA/2432.454364refsdFASDDASFDSADWE24Z";
    public static string ApiKeyName = "api_key";
    public static string ApiKey = "curso_api_IlTevUM/z0ey3NwCV/unWg==";
    public static SmtpConfiguration Smtp = new SmtpConfiguration();

    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}