using Domains.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domains.DTO
{
    public class ClientAccountDTO
    {
        [Required()]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Tipo da pessoa é obrigatório.")]
        public Persons Person { get; set; }

        [StringLength(100, ErrorMessage = "Nome muito longe.")]
        public string Name { get; set; }

        public int Age { get; set; }

        public Genders Gender { get; set; }

        [Required(ErrorMessage = "Tipo da conta é obrigatório.")]
        public AccountsType AccountType { get; set; }
    }
}
