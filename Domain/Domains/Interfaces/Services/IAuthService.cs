using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        AuthClientsDTO Login(AuthDTO auth);
    }
}
