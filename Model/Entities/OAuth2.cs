namespace Model.Entities
{
    /// <summary>
    /// Modelo de Autenticação com OAuth2
    /// </summary>
    public class OAuth2
    {
        public string? access_token { get; set; }
        public string? token_type { get; set; }
        public int expires_in { get; set; }
        public bool active { get; set; }
        public string? scope { get; set; }
    }

}
