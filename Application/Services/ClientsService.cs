using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using Domain.Entities;
using Domain.Exceptions;
using CrossCutting;
using System.Net;
using Domain.Responses;
using Domain.Enums;

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
                Clients client = _iClientsRepository.GetClient(id);

                client.Password = null;

                return client;
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

        public void AddClient(Clients client)
        {
            try
            {
                CheckEnumsType(client);

                Clients clientResult = GetClient(client.Document);

                if (clientResult != null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.DOCUMENT_ALREADY_REGISTERED, new { client.Document });
                }

                client.Password = Crypto.Password.Hash(client.Password);

                _iClientsRepository.AddClient(client);
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

        public void UpdateClient(Clients client)
        {
            try
            {
                CheckEnumsType(client);

                Clients clientResult = GetClient((long) client.Id);

                if (clientResult == null)
                {
                    throw new CustomException(HttpStatusCode.NotFound, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND);
                }

                Clients clientCheckDocument = GetClient(client.Document);

                if (clientCheckDocument != null)
                {
                    if(clientResult.Id != clientCheckDocument.Id)
                    {
                        throw new CustomException(HttpStatusCode.NotFound, CustomResponseMessage.Clients.ConditionValidations.DOCUMENT_ALREADY_REGISTERED, new { client.Document });
                    }
                }

                client.Password = Crypto.Password.Hash(client.Password);

                _iClientsRepository.UpdateClient(client);
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

        private void CheckEnumsType(Clients client)
        {
            if (!Enum.IsDefined(typeof(Genders), client.Gender))
                throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INVALID_GENDER, new { client.Gender });
        }
    }
}