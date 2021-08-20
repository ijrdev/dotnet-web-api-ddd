using System.Collections.Generic;
using Domain = Domains.Accounts;

namespace Interfaces.Repositories.Accounts
{
    public interface IAccountsRepository
    {
        Domain.Accounts GetAccount(string accountNumber);
        IEnumerable<Domain.Accounts> GetAccounts(long clientId);
        void AddAccount(Domain.Accounts account, bool newClient = false);
    }
}
