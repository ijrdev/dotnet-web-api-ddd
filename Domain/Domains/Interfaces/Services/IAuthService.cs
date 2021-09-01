using Domain.Domain.Core.DTO;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IAuthService
    {
        AuthOutDTO Login(AuthInDTO authIn);
    }
}
