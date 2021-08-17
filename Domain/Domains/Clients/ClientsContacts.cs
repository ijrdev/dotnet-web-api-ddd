namespace Domains.Clients
{
    public class ClientsContacts
    {
        public long? Id { get; set; }
        public string Phone { get; set; }
        public Clients Client { get; set; }
    }
}