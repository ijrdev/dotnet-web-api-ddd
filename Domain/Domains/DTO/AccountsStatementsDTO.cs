using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class AccountsStatementsDTO
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public IEnumerable<AccountsTransactions> AccountTransactions { get; set; }
    }
}
