using Infrastructure.CrossCutting.Core;
using Domain.Domain.Core.DTO;
using Domain.Domain.Core.Interfaces.Services;
using Domain.Domain.Core.Entities;
using System.Net;
using AutoMapper;
using Domain.Domain.Core.Responses;
using Domain.Domain.Core.Exceptions;
using System;
using Domain.Domain.Core.Interfaces.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Domain.Domain.Core.Consts;

namespace Infrastructure.Services.Core
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _iConfiguration;
        private readonly IClientsRepository _iClientsRepository;

        public AuthService(IConfiguration iConfiguration, IClientsRepository iClientsRepository)
        {
            _iConfiguration = iConfiguration;
            _iClientsRepository = iClientsRepository;
        }

        public AuthOutDTO Login(AuthInDTO authIn)
        {
            try
            {
                Clients client = _iClientsRepository.GetClient(authIn.Email);

                if (client == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND, new { authIn.Email });
                }

                bool checkPassword = Crypto.Password.Verify(authIn.Password, client.Password);

                if (!checkPassword)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INCORRECT_PASSWORD, new { authIn.Email });
                }

                IMapper mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Clients, AuthOutDTO>();
                }).CreateMapper();

                AuthOutDTO authOut = mapper.Map<AuthOutDTO>(client);

                authOut.Token = GenerateJWT(client);

                return authOut;
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

        private string GenerateJWT(Clients client)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(AutenticatedUser.Id, client.Id.ToString(), ClaimValueTypes.Integer64),
                    new Claim(AutenticatedUser.Document, client.Document.ToString(), ClaimValueTypes.String),
                    new Claim(AutenticatedUser.Email, client.Email, ClaimValueTypes.String)
                }),
                Expires = DateTime.UtcNow.AddHours(_iConfiguration.GetValue<int>("Token:Time")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_iConfiguration.GetValue<string>("Token:Key"))), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
