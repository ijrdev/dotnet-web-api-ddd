using Database.Contexts;
using Interfaces.Repositories.Clients;
using System;
using System.Linq;

namespace Repositories.Clients
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly DotnetWebApiDDDDbContext _dotnetWebApiDDDDbContext;
        public ClientsRepository(DotnetWebApiDDDDbContext dotnetWebApiDDDDbContext)
        {
            _dotnetWebApiDDDDbContext = dotnetWebApiDDDDbContext;
        }

        public void AddClient()
        {
            var result = _dotnetWebApiDDDDbContext.Clients.ToList();

            Console.WriteLine(result.Count());

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void UpdateClient()
        {
            throw new System.NotImplementedException();
        }
    }
}
