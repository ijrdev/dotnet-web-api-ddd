using Domain = Domains.Accounts;

namespace Interfaces.Repositories.Accounts
{
    public interface IAccountsRepository
    {
        void AddAccount(Domain.Accounts account);
    }
}
