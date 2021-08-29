using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountsTransactionsRepository
    {
        void Register(AccountsTransactions accountTransaction);
        IEnumerable<AccountsTransactions> GetStatements(long accountId);
    }
}
