using Domain.Domain.Core.Entities;
using System.Collections.Generic;

namespace Domain.Domain.Core.Interfaces.Repositories
{
    public interface IAccountsTransactionsRepository
    {
        void Register(AccountsTransactions accountTransaction);
        IEnumerable<AccountsTransactions> GetStatements(long accountId);
    }
}
