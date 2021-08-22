using Domain.DTO;

namespace Interfaces.Services
{
    public interface IAuthService
    {
        AuthClientDTO Login(AuthDTO auth);
    }
}
