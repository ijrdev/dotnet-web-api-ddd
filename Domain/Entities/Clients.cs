using System.ComponentModel.DataAnnotations;
using Domain.Domain.Core.Responses;

namespace Domain.Domain.Core.Entities
{
    public class Clients
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = ResponseMessages.Clients.DomainValidations.REQUIRED_DOCUMENT)]
        [RegularExpression(@"([0-9]{11})", ErrorMessage = ResponseMessages.Clients.DomainValidations.INVALID_DOCUMENT)]
        public string Document { get; set; }

        [Required(ErrorMessage = ResponseMessages.Clients.DomainValidations.REQUIRED_NAME)]
        [StringLength(100, ErrorMessage = ResponseMessages.Clients.DomainValidations.LONG_NAME)]
        public string Name { get; set; }

        [Required(ErrorMessage = ResponseMessages.Clients.DomainValidations.REQUIRED_AGE)]
        [Range(1, int.MaxValue, ErrorMessage = ResponseMessages.Clients.DomainValidations.INVALID_AGE)]
        public int Age { get; set; }

        [Required(ErrorMessage = ResponseMessages.Clients.DomainValidations.REQUIRED_GENDER)]
        [Range(1, int.MaxValue, ErrorMessage = ResponseMessages.Clients.DomainValidations.INVALID_GENDER)]
        public int Gender { get; set; }

        [Required(ErrorMessage = ResponseMessages.Clients.DomainValidations.REQUIRED_EMAIL)]
        [StringLength(100, ErrorMessage = ResponseMessages.Clients.DomainValidations.LONG_EMAIL)]
        [EmailAddress(ErrorMessage = ResponseMessages.Clients.DomainValidations.INVALID_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = ResponseMessages.Clients.DomainValidations.REQUIRED_PASSWORD)]
        public string Password { get; set; }
    }
}