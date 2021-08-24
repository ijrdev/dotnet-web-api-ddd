using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IClientsService
    {
        Clients GetClient(long id);
        Clients GetClient(string documentEmail);
        void AddClient(Clients client);
        void UpdateClient(Clients client);
    }
}
