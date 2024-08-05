namespace Model.Entities
{

    /// <summary>
    /// Classe Raiz para criação e mapeio da Cobrança Imediata com QR Code Pix
    /// </summary>
    public class QRCodeImediato
    {
        public Calendario? calendario { get; set; }
        public string? txid { get; set; }
        public int? revisao { get; set; }
        public Loc? loc { get; set; }
        public string? location { get; set; }
        public string? status { get; set; }
        public Devedor? devedor { get; set; }
        public Valor? valor { get; set; }
        public string? pixCopiaECola { get; set; }
        public string? chave { get; set; }
    }
}
