using System.ComponentModel.DataAnnotations;
using Domain.Responses;

namespace Domain.DTO
{
    public class AuthDTO
    {
        [StringLength(100, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.LONG_EMAIL)]
        [EmailAddress(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.INVALID_EMAIL)]
        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_PASSWORD)]
        public string Password { get; set; }
    }
}
