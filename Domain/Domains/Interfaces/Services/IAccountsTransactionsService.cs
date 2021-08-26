using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IAccountsTransactionsService
    {
        void Register(TransactionsDTO Transaction);
    }
}
