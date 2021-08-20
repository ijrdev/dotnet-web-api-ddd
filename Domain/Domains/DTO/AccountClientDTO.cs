using System.ComponentModel.DataAnnotations;
using CrossCutting;

namespace Domains.DTO
{
    public class AccountClientDTO
    {
        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_DOCUMENT)]
        public string Document { get; set; }

        [StringLength(100, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.LONG_NAME)]
        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_NAME)]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.INVALID_AGE)]
        public int Age { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.INVALID_GENDER)]
        public int Gender { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.INVALID_PERSON)]
        public int Person { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_ACCOUNT_TYPE)]
        public int AccountType { get; set; }
    }
}
