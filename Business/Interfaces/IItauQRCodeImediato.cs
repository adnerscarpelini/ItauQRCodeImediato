using Model.Entities;

namespace Business.Interfaces
{
    public interface IItauQRCodeImediato
    {
        Task<OAuth2> Authenticate(string ambiente, string clientId, string clientSecret);
        Task<QRCodeImediato> PostQRCodeImediato(string ambiente, string clientId, OAuth2 oauth2, QRCodeImediato qrCodeImediato);

    }
}
