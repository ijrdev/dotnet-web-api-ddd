using Domains.DTO;
using Domain = Domains.Accounts;

namespace Interfaces.Services.Accounts
{
    public interface IAccountsService
    {
        void AddAccount(AccountClientDTO accountClient);
        Domain.Accounts GetAccount(string accountNumber);
    }
}