using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        AuthOutDTO Login(AuthInDTO authIn);
    }
}
