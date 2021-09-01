using Domain.Domain.Core.Entities;
using System.Collections.Generic;

namespace Domain.Domain.Core.DTO
{
    public class AccountsStatementsDTO
    {
        public string AccountNumber { get; set; }
        public double Value { get; set; }
        public IEnumerable<AccountsTransactions> AccountTransactions { get; set; }
    }
}
