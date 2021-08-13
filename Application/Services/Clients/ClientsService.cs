using CrossCutting;
using Interfaces.Repositories.Clients;
using Interfaces.Services.Clients;
using System;

namespace Services.Clients
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _iClientsRepository;

        public ClientsService(IClientsRepository iClientsRepository)
        {
            _iClientsRepository = iClientsRepository;
        }

        public void AddClient()
        {
            try
            {
                _iClientsRepository.AddClient();
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

        public void UpdateClient()
        {
            throw new NotImplementedException();
        }
    }
}