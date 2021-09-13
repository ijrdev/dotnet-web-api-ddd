using Domain.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IClientsService
    {
        Task<Clients> GetClient(long id);
        Task<Clients> GetClient(string documentEmail);
        Task AddClient(Clients client);
        Task UpdateClient(Clients client);
    }
}
