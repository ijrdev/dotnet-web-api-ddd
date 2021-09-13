using Domain.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Domain.Core.Interfaces.Repositories
{
    public interface IAccountsTransactionsRepository
    {
        Task Register(AccountsTransactions accountTransaction);
        Task<IEnumerable<AccountsTransactions>> GetStatements(long accountId);
    }
}
