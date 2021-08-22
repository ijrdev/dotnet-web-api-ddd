using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        AuthClientDTO Login(AuthDTO auth);
    }
}
