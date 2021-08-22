using Database.Contexts;
using Database.Factories;
using Domain.Database;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;
using System.Net;
using Domain.Exceptions;
using Domain.Responses;

namespace Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        public Clients GetClient(string documentEmail)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Document == documentEmail || c.Email == documentEmail).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Clients GetClient(long id)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    return context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Id == id).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateClient(long id, Clients client)
        {
            try
            {
                using (DotnetWebApiDDDDbContext context = new DotnetWebApiDDDDbContext(DatabaseFactory.CreateConnection(DatabaseConnections.DOTNET_WEB_API_DDD)))
                {
                    Clients clientResult = context.Clients.FindAsync(id).GetAwaiter().GetResult();

                    if (clientResult == null)
                    {
                        throw new CustomException(HttpStatusCode.NotFound, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND);
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
