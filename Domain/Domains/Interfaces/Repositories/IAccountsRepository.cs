using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        Accounts GetAccount(string accountNumber);
        IEnumerable<Accounts> GetAccounts(long clientId);
        void AddAccount(Accounts account, bool newClient = false);
    }
}
