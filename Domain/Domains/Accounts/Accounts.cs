using Domains.Enums;
using System.ComponentModel.DataAnnotations;
using Domain = Domains.Clients;

namespace Domains.Accounts
{
    public class Accounts
    {
        public long? Id { get; set; }

        [EnumDataType(typeof(AccountsType), ErrorMessage = "Tipo da conta é obrigatório.")]
        public AccountsType AccountType { get; set; }

        public string AccountNumber { get; set; }

        public double Balance { get; set; }

        public virtual Domain.Clients Client { get; set; }
    }
}
