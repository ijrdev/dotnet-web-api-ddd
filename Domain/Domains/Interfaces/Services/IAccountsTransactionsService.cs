using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IAccountsTransactionsService
    {
        void Deposit(DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        void Withdraw(long clientId, DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        void Transfer(long clietId, TransferTransactionsDTO transferTransaction);
        //void CheckBalance(TransactionsDTO transaction);
    }
}
