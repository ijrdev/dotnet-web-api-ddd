using Domain.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IAccountsService
    {
        Task<Accounts> GetAccount(string accountNumber);
        Task<Accounts> GetAccount(long clientId);
        Task AddAccount(long clientId, Accounts accountClient);
    }
}