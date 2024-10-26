using Service_Auth.Entities;

namespace Service_Auth.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Account account);
    }
}
