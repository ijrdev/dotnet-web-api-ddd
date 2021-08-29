using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        Accounts GetAccount(string accountNumber);
        Accounts GetAccount(long clientId);
        void AddAccount(Accounts account);
        void UpdateAccount(Accounts account);
    }
}
