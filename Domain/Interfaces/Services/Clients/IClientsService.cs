using Domains.DTO;
using Domain = Domains.Clients;

namespace Interfaces.Services.Clients
{
    public interface IClientsService
    {
        Domain.Clients GetClient(long id);
        Domain.Clients GetClient(string documentEmail);
        void UpdateClient(long id, Domain.Clients client);
    }
}
