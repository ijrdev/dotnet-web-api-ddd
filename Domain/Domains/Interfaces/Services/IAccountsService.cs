using Domain.Domain.Core.Entities;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IAccountsService
    {
        Accounts GetAccount(string accountNumber);
        Accounts GetAccount(long clientId);
        void AddAccount(long clientId, Accounts accountClient);
    }
}