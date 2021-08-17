using CrossCutting;
using Database.Contexts;
using Database.Factories;
using Domains.Database;
using Domains.Helpers;
using Interfaces.Repositories.Clients;
using System;
using System.Net;
using Domains.Enums;

namespace Repositories.Clients
{
    public class ClientsRepository : IClientsRepository
    {
        public Domains.Clients.Clients GetClient(string cpf)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.FindAsync(cpf).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Domains.Clients.Clients GetClient(long id)
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

        public void AddClient(Domains.Clients.Clients client)
        {
            using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
            {
                Domains.Clients.Clients clientResult = GetClient(client.Cpf);

                if (clientResult != null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.CLIENT_CPF_ALREADY_REGISTERED);
                }

                Domains.Accounts.Accounts account = new Domains.Accounts.Accounts()
                {
                    AccountType = (AccountsType) 10,
                    AccountNumber = "10"
                };

                context.Entry(clientResult).CurrentValues.SetValues(client);

                context.SaveChangesAsync().GetAwaiter().GetResult();
            }
        }

        public void UpdateClient(long id, Domains.Clients.Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnectionString.DOTNET_WEB_API_DDD)))
                {
                    Domains.Clients.Clients clientResult = context.Clients.FindAsync(id).GetAwaiter().GetResult();

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

        public void DeleteClient(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
