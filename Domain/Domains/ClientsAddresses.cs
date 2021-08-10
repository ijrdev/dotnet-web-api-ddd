namespace Domains
{
    public class ClientsAddresses
    {
        public long Id { get; set; } = null;
        public string ZipCode { get; set; } = "";
        public string Street { get; set; } = "";
        public string Number { get; set; } = "";
        public string District { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public long Id_Client { get; set; } = null;
    }
}