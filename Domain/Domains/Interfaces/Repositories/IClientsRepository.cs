using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IClientsRepository
    {
        Clients GetClient(long id);
        Clients GetClient(string documentEmail);
        void AddClient(Clients client);
        void UpdateClient(Clients client);
    }
}
