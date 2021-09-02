using Domain.Domain.Core.Entities;

namespace Domain.Domain.Core.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        Accounts GetAccount(string accountNumber);
        Accounts GetAccount(long clientId);
        void AddAccount(Accounts account);
        void UpdateAccount(Accounts account);
    }
}
