using System.ComponentModel.DataAnnotations;
using Domain.Responses;

namespace Domain.Entities
{
    public class Accounts
    {
        public long? Id { get; set; }

        public string AccountNumber { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.REQUIRED_BALANCE)]
        [Range(0, double.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_BALANCE)]
        public double Balance { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.REQUIRED_ACCOUNT_TYPE)]
        [Range(1, int.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_ACCOUNT_TYPE)]

        public virtual Clients Client { get; set; }
    }
}
