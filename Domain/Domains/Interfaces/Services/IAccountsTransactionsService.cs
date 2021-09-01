using Domain.Domain.Core.DTO;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IAccountsTransactionsService
    {
        void Deposit(DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        void Withdraw(long clientId, DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        void Transfer(long clietId, TransferTransactionsDTO transferTransaction);
        AccountsStatementsDTO GetStatements(long clientId);
    }
}
