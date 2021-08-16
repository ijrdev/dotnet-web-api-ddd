using Domain = Domains.Clients;

namespace Interfaces.Repositories.Clients
{
    public interface IClientsRepository
    {
        Domain.Clients GetClient(long id);

        void AddClient(Domain.Clients client);

        void UpdateClient(long id, Domain.Clients client);
    }
}
