using System.ComponentModel.DataAnnotations;
using Domain.Domain.Core.Responses;

namespace Domain.Domain.Core.Entities
{
    public class Accounts
    {
        public long? Id { get; set; }

        public string AccountNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = ResponseMessages.Accounts.DomainValidations.INVALID_VALUE)]
        public double Value { get; set; }

        public virtual Clients Client { get; set; }
    }
}
