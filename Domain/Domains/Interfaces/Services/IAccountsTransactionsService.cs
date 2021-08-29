using Domain.DTO;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IAccountsTransactionsService
    {
        void Deposit(DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        void Withdraw(long clientId, DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        void Transfer(long clietId, TransferTransactionsDTO transferTransaction);
        AccountsStatementsDTO GetStatements(long clientId);
    }
}
