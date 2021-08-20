using Domain = Domains.Clients;

namespace Interfaces.Repositories.Clients
{
    public interface IClientsRepository
    {
        Domain.Clients GetClient(long id);
        Domain.Clients GetClient(string document);
        void AddClient(Domain.Clients client);
        void UpdateClient(long id, Domain.Clients client);
        void DeleteClient(long id);
        void DeleteClient(string document);
    }
}
