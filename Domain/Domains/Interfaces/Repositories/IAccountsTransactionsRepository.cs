using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountsTransactionsRepository
    {
        void Register(AccountsTransactions accountTransaction);
    }
}
