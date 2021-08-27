using CrossCutting;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Entities;
using System.Net;
using AutoMapper;
using Domain.Responses;
using Domain.Exceptions;
using System;
using Domain.Interfaces.Repositories;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientsRepository _iClientsRepository;

        public AuthService(IClientsRepository iClientsRepository)
        {
            _iClientsRepository = iClientsRepository;
        }

        public AuthClientsDTO Login(AuthDTO auth)
        {
            try
            {
                Clients client = _iClientsRepository.GetClient(auth.Email);

                if (client == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND, new { auth.Email });
                }

                bool checkPassword = Crypto.Password.Verify(auth.Password, client.Password);

                if (!checkPassword)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INCORRECT_PASSWORD, new { auth.Email });
                }

                IMapper mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Clients, AuthClientsDTO>();
                }).CreateMapper();

                AuthClientsDTO authClientDTO = mapper.Map<AuthClientsDTO>(client);

                authClientDTO.Token = Token.GenerateToken(client);

                return authClientDTO;
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
