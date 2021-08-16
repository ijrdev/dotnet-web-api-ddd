using CrossCutting;
using Database.Contexts;
using Database.Factories;
using Domains.Database;
using Domains.Helpers;
using Interfaces.Repositories.Clients;
using System;
using System.Net;
using Domain = Domains.Clients;

namespace Repositories.Clients
{
    public class ClientsRepository : IClientsRepository
    {
        //private readonly DotnetWebApiDDDDbContext _dotnetWebApiDDDDbContext;

        //public ClientsRepository(DotnetWebApiDDDDbContext dotnetWebApiDDDDbContext)
        //{
        //    _dotnetWebApiDDDDbContext = dotnetWebApiDDDDbContext;
        //}

        public Domain.Clients GetClient(long id)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.FindAsync(id).GetAwaiter().GetResult();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddClient(Domain.Clients client)
        {
            try
            {
                    //context.Clients.Add(client);

                    //await context.SaveChangesAsync();
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateClient(long id, Domain.Clients client)
        {
            try
            {
                //Console.WriteLine("Save Starting");
                //client.Id = id;

                //var clientResult = await _dotnetWebApiDDDDbContext.Clients.ToListAsync();

                //if (clientResult == null)
                //{
                //    throw new CustomException(HttpStatusCode.NotFound, CustomResponseMessage.NOT_FOUND);
                //}

                //_dotnetWebApiDDDDbContext.Entry(clientResult).CurrentValues.SetValues(client);

                //await _dotnetWebApiDDDDbContext.SaveChangesAsync();
                //Console.WriteLine("Save Complete");

                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    Domain.Clients clientResult = GetClient(id);

                    if (clientResult == null)
                    {
                        throw new CustomException(HttpStatusCode.NotFound, CustomResponseMessage.NOT_FOUND);
                    }

                    client.Id = id;

                    context.Entry(clientResult).CurrentValues.SetValues(client);

                    context.SaveChangesAsync().GetAwaiter().GetResult();
                }
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
