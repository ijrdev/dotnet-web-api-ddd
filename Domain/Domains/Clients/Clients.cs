using Domains.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Clients
{
    public class Clients
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string Cpf { get; set; }
   
        [StringLength(100, ErrorMessage = "Nome muito longo.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }

        public int? Age { get; set; }

        public Genders? Gender { get; set; }

        [EnumDataType(typeof(Persons), ErrorMessage = "Tipo da pessoa é obrigatório.")]
        public Persons Person { get; set; }

        public virtual IEnumerable<Accounts.Accounts> Accounts { get; set; }

    }
}