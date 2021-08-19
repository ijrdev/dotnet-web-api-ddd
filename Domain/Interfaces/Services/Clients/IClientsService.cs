using Domains.DTO;
using Domain = Domains.Clients;

namespace Interfaces.Services.Clients
{
    public interface IClientsService
    {
        Domain.Clients GetClient(long id);
        Domain.Clients GetClient(string cpf);
        void AddClient(AccountClientDTO accountClient);
        void UpdateClient(long id, Domain.Clients client);
    }
}
