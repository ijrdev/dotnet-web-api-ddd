using Domain = Domains.Clients;

namespace Interfaces.Services.Clients
{
    public interface IClientsService
    {
        Domain.Clients GetClient(long id);

        void AddClient(Domain.Clients client);

        void UpdateClient(long id, Domain.Clients client);
    }
}
