using Domain.DTO;
using System.Collections.Generic;
using Domain.Entities;

namespace Interfaces.Services
{
    public interface IAccountsService
    {
        Accounts GetAccount(string accountNumber);
        IEnumerable<Accounts> GetAccounts(long clientId);
        void AddAccount(AccountClientDTO accountClient);
    }
}