using System.Collections.Generic;
using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IAccountsService
    {
        Accounts GetAccount(string accountNumber);
        IEnumerable<Accounts> GetAccounts(long clientId);
        void AddAccount(long clientId, Accounts accountClient);
        void Deposit(TransactionsDTO transaction);
    }
}