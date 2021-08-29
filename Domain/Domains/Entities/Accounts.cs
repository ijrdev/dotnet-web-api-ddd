using System.ComponentModel.DataAnnotations;
using Domain.Responses;

namespace Domain.Entities
{
    public class Accounts
    {
        public long? Id { get; set; }

        public string AccountNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_VALUE)]
        public double Value { get; set; }

        public virtual Clients Client { get; set; }
    }
}
