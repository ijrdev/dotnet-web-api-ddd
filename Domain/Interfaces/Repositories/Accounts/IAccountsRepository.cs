using System.Collections.Generic;
using Domain = Domains.Accounts;

namespace Interfaces.Repositories.Accounts
{
    public interface IAccountsRepository
    {
        void AddAccount(Domain.Accounts account);
        Domain.Accounts GetAccount(string accountNumber);
        IEnumerable<Domain.Accounts> GetAccounts(long clientId);
    }
}
