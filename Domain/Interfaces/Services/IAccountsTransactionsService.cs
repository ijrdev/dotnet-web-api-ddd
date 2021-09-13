using Domain.Domain.Core.DTO;
using System.Threading.Tasks;

namespace Domain.Domain.Core.Interfaces.Services
{
    public interface IAccountsTransactionsService
    {
        Task Deposit(DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        Task Withdraw(long clientId, DepositWithdrawTransactionsDTO depositWithdrawTransaction);
        Task Transfer(long clietId, TransferTransactionsDTO transferTransaction);
        Task<AccountsStatementsDTO> GetStatements(long clientId);
    }
}
