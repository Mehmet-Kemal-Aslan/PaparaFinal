using PaparaFinalData.Entity;

namespace PaparaProjectBusiness.Token
{
    public interface ITokenService
    {
        Task<string> GetToken(User user);
    }
}
