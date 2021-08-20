using CrossCutting;
using Domains.DTO;
using Interfaces.Repositories.Auth;
using Interfaces.Services.Auth;
using Interfaces.Services.Clients;
using Domain = Domains.Clients;
using System.Net;
using AutoMapper;

namespace Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _iAuthRepository;
        private readonly IClientsService _iClientsService;

        public AuthService(IAuthRepository iAuthRepository, IClientsService iClientsService)
        {
            _iAuthRepository = iAuthRepository;
            _iClientsService = iClientsService;
        }

        public AuthClientDTO Login(AuthDTO auth)
        {
            Domain.Clients client = _iClientsService.GetClient(auth.Email);

            if (client == null)
            {
                throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND, auth.Email);
            }

            bool checkPassword = Crypto.Password.Verify(auth.Password);

            if(!checkPassword)
            {
                throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INCORRECT_PASSWORD, checkPassword);
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Clients, AuthClientDTO>();
            }).CreateMapper();

            AuthClientDTO authClientDTO = mapper.Map<AuthClientDTO>(client);
            authClientDTO.Token = Token.GenerateToken(client);

            return authClientDTO;
        }
    }
}
