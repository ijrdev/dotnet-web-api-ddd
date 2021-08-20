using CrossCutting;
using Interfaces.Repositories.Clients;
using Interfaces.Services.Clients;
using System;
using Domain = Domains.Clients;

namespace Services.Clients
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _iClientsRepository;

        public ClientsService(IClientsRepository iClientsRepository)
        {
            _iClientsRepository = iClientsRepository;
        }

        public Domain.Clients GetClient(long id)
        {
            try
            {
                return _iClientsRepository.GetClient(id);
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

        public Domain.Clients GetClient(string documentEmail)
        {
            try
            {
                return _iClientsRepository.GetClient(documentEmail);
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
                _iClientsRepository.UpdateClient(id, client);
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