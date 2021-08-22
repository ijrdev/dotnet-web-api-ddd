using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using Domain.Entities;
using Domain.Exceptions;

namespace Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _iClientsRepository;

        public ClientsService(IClientsRepository iClientsRepository)
        {
            _iClientsRepository = iClientsRepository;
        }

        public Clients GetClient(long id)
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

        public Clients GetClient(string documentEmail)
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

        public void UpdateClient(long id, Clients client)
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