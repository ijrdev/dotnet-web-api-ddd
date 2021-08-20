using Domains.DTO;

namespace Interfaces.Services.Auth
{
    public interface IAuthService
    {
        AuthClientDTO Login(AuthDTO auth);
    }
}
