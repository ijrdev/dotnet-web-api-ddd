using CrossCutting;
using Interfaces.Repositories.Clients;
using Interfaces.Services.Clients;
using System;
using System.Net;
using System.Collections.Generic;

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
                Console.WriteLine("SERVICE");

                _iClientsRepository.AddClient();

                // throw new CustomException(HttpStatusCode.NotFound, "Erro ao procurar o recurso.");
                throw new Exception();
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
            throw new System.NotImplementedException();
        }
    }
}