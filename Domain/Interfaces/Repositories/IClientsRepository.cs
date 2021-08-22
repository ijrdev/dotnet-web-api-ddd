using Domain.Entities;

namespace Interfaces.Repositories
{
    public interface IClientsRepository
    {
        Clients GetClient(long id);
        Clients GetClient(string documentEmail);
        void UpdateClient(long id, Clients client);
    }
}
