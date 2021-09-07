using Domain.Domain.Core.Interfaces.Repositories;
using Domain.Domain.Core.Interfaces.Services;
using System;
using Domain.Domain.Core.Entities;
using Domain.Domain.Core.Exceptions;
using Infrastructure.CrossCutting.Core;
using System.Net;
using Domain.Domain.Core.Responses;
using Domain.Domain.Core.Enums;

namespace Infrastructure.Services.Core
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
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Clients.ConditionValidations.DOCUMENT_ALREADY_REGISTERED, new { client.Document });
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
                    throw new CustomException(HttpStatusCode.NotFound, ResponseMessages.Clients.ConditionValidations.CLIENT_NOT_FOUND);
                }

                Clients clientCheckDocument = GetClient(client.Document);

                if (clientCheckDocument != null)
                {
                    if(clientResult.Id != clientCheckDocument.Id)
                    {
                        throw new CustomException(HttpStatusCode.NotFound, ResponseMessages.Clients.ConditionValidations.DOCUMENT_ALREADY_REGISTERED, new { client.Document });
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
                throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Clients.ConditionValidations.INVALID_GENDER, new { client.Gender });
        }
    }
}