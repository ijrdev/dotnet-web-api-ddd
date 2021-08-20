using System.ComponentModel.DataAnnotations;
using CrossCutting;
using Domain = Domains.Clients;

namespace Domains.Accounts
{
    public class Accounts
    {
        public long? Id { get; set; }

        public string AccountNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_BALANCE)]
        public double Balance { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_ACCOUNT_TYPE)]
        public int AccountType { get; set; }

        public virtual Domain.Clients Client { get; set; }
    }
}
