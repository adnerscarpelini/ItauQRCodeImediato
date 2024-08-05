using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.Entities
{
    /// <summary>
    /// Modelo de Erro retornado pela API
    /// </summary>
    public class ErroApi
    {
        public string? message { get; set; }
        public Error error { get; set; }
    }

    public class Error
    {
        public int? status { get; set; }
        public string? message { get; set; }
    }
}
