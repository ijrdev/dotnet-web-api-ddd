using System.ComponentModel.DataAnnotations;

namespace Domains.Clients
{
    public class ClientsContacts
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Phone { get; set; }

        public Clients Client { get; set; }
    }
}