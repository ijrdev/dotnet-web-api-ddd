using Domain.Domain.Core.DTO;
using System.Threading.Tasks;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthOutDTO> Login(AuthInDTO authIn);
    }
}
