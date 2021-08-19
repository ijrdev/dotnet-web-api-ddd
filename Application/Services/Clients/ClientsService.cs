using CrossCutting;
using Domains.DTO;
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
            throw new NotImplementedException();
        }

        public Domain.Clients GetClient(string cpf)
        {
            try
            {
                return _iClientsRepository.GetClient(cpf);
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

        public void AddClient(AccountClientDTO accountClient)
        {
            try
            {
                //_iClientsRepository.UpdateClient(id, client);
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