using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IAccountsService
    {
        Accounts GetAccount(string accountNumber);
        Accounts GetAccount(long clientId);
        void AddAccount(long clientId, Accounts accountClient);
    }
}