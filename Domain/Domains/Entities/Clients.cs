using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Responses;

namespace Domain.Entities
{
    public class Clients
    {
        public long? Id { get; set; }

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

        [StringLength(100, ErrorMessage = CustomResponseMessage.Clients.DomainValidations.LONG_EMAIL)]
        [EmailAddress(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.INVALID_EMAIL)]
        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.Clients.DomainValidations.REQUIRED_PASSWORD)]
        public string Password { get; set; }

        public virtual IEnumerable<Accounts> Accounts { get; set; }
    }
}