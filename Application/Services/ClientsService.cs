using Interfaces.Repositories;
using Interfaces.Services;
using System;

namespace Services
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
            Console.WriteLine("SERVICE");

            _iClientsRepository.AddClient();

            //throw new System.NotImplementedException();
        }

        public void UpdateClient()
        {
            throw new System.NotImplementedException();
        }
    }
}