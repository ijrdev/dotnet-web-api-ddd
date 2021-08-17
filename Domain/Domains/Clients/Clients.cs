using Domains.Enums;
using System.Collections.Generic;

namespace Domains.Clients
{
    public class Clients
    {
        public long Id { get; set; }
        public string Cpf { get; set; }
        public Persons Person { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }
        public virtual IEnumerable<Accounts.Accounts> Accounts { get; set; }
    }
}