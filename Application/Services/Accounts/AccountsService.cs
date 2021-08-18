using AutoMapper;
using CrossCutting;
using Domains.DTO;
using Interfaces.Repositories.Accounts;
using Interfaces.Services.Accounts;
using System;
using Domains.Enums;

namespace Services.Clients
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _iAccountsRepository;

        public AccountsService(IAccountsRepository iAccountsRepository)
        {
            _iAccountsRepository = iAccountsRepository;
        }

        public void AddAccount(ClientAccountDTO clientAccount)
        {
            try
            {
                IMapper mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ClientAccountDTO, Domains.Clients.Clients>();
                    cfg.CreateMap<ClientAccountDTO, Domains.Accounts.Accounts>();
                }).CreateMapper();

                Domains.Clients.Clients client = mapper.Map<Domains.Clients.Clients>(clientAccount);
                Domains.Accounts.Accounts account = mapper.Map<Domains.Accounts.Accounts>(clientAccount);

                //client.Gender = (Genders) Enum.Parse(typeof(Genders), Enum.GetName(typeof(Genders), client.Gender));
                //client.Person = (Persons) Enum.Parse(typeof(Persons), Enum.GetName(typeof(Persons), client.Person));

                //account.AccountType = (AccountsType)(int) Enum.Parse(typeof(AccountsType), Enum.GetName(typeof(AccountsType), account.AccountType));
                account.Balance = 0;
                account.AccountNumber = Guid.NewGuid().ToString();
                account.Client = client;

                _iAccountsRepository.AddAccount(account);
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