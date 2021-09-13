using Domain.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Domain.Domain.Core.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        Task<Accounts> GetAccount(string accountNumber);
        Task<Accounts> GetAccount(long clientId);
        Task AddAccount(Accounts account);
        Task UpdateAccount(Accounts account);
    }
}
