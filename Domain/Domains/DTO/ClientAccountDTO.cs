using Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domains.DTO
{
    public class ClientAccountDTO
    {
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string Cpf { get; set; }

        [StringLength(100, ErrorMessage = "Nome muito longo.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }

        public int? Age { get; set; }

        public Genders? Gender { get; set; }

        [EnumDataType(typeof(Persons), ErrorMessage = "Tipo da pessoa é obrigatório.")]
        public Persons Person { get; set; }

        [EnumDataType(typeof(AccountsType), ErrorMessage = "Tipo da conta é obrigatório.")]
        public AccountsType AccountType { get; set; }
    }
}
