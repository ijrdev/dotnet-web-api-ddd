using System.ComponentModel.DataAnnotations;
using Domain.Domain.Core.Responses;

namespace Domain.Domain.Core.DTO
{
    public class AuthInDTO
    {
        [StringLength(100, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.LONG_EMAIL)]
        [EmailAddress(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.INVALID_EMAIL)]
        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_PASSWORD)]
        public string Password { get; set; }
    }
}
