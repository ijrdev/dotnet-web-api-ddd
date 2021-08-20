using Domains.DTO;
using System.Collections.Generic;
using Domain = Domains.Accounts;

namespace Interfaces.Services.Accounts
{
    public interface IAccountsService
    {
        void AddAccount(AccountClientDTO accountClient);
        Domain.Accounts GetAccount(string accountNumber);
        IEnumerable<Domain.Accounts> GetAccounts(long clientId);
    }
}