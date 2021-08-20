using Domain = Domains.Clients;

namespace Interfaces.Repositories.Clients
{
    public interface IClientsRepository
    {
        Domain.Clients GetClient(long id);
        Domain.Clients GetClient(string documentEmail);
        void UpdateClient(long id, Domain.Clients client);
    }
}
