using Domains.Enums;
using Domain = Domains.Clients;

namespace Domains.Accounts
{
    public class Accounts
    {
        public long Id { get; set; }
        public AccountsType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public virtual Domain.Clients Client { get; set; }
    }
}
