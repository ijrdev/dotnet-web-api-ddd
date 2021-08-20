using AutoMapper;
using CrossCutting;
using Domains.DTO;
using Domains.Enums;
using Domains.Helpers;
using Interfaces.Repositories.Accounts;
using Interfaces.Services.Accounts;
using Interfaces.Services.Clients;
using System;
using System.Collections.Generic;
using System.Net;

namespace Services.Clients
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _iAccountsRepository;
        private readonly IClientsService _iClientsService;

        public AccountsService(IAccountsRepository iAccountsRepository, IClientsService iClientsService)
        {
            _iAccountsRepository = iAccountsRepository;
            _iClientsService = iClientsService;
        }

        public Domains.Accounts.Accounts GetAccount(string accountNumber)
        {
            return _iAccountsRepository.GetAccount(accountNumber);
        }

        public IEnumerable<Domains.Accounts.Accounts> GetAccounts(long clientId)
        {
            return _iAccountsRepository.GetAccounts(clientId);
        }

        public void AddAccount(AccountClientDTO accountClient)
        {
            try
            {
                IMapper mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AccountClientDTO, Domains.Clients.Clients>();
                    cfg.CreateMap<AccountClientDTO, Domains.Accounts.Accounts>();
                }).CreateMapper();

                Domains.Clients.Clients clientMapped = mapper.Map<Domains.Clients.Clients>(accountClient);
                Domains.Accounts.Accounts accountMapped = mapper.Map<Domains.Accounts.Accounts>(accountClient);

                if(!Enum.IsDefined(typeof(Genders), clientMapped.Gender))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INVALID_GENDER, clientMapped.Gender);

                if (!Enum.IsDefined(typeof(Persons), clientMapped.Person))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INVALID_PERSON, clientMapped.Person);

                if (!Enum.IsDefined(typeof(AccountsType), accountMapped.AccountType))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.INVALID_ACCOUNT_TYPE, accountMapped.AccountType);

                Domains.Clients.Clients client = _iClientsService.GetClient(clientMapped.Document);

                if(client != null)
                {
                    IEnumerable<Domains.Accounts.Accounts> accounts = GetAccounts((long) client.Id);

                    foreach(Domains.Accounts.Accounts acc in accounts)
                    {
                        if(acc.AccountType == accountMapped.AccountType)
                            throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_ALREADY_REGISTERED, accountMapped.AccountType);
                    }

                    accountMapped.AccountNumber = GenerateAccountNumber();
                    accountMapped.Client = client;

                    _iAccountsRepository.AddAccount(accountMapped);
                }
                else
                {
                    accountMapped.AccountNumber = GenerateAccountNumber();
                    accountMapped.Client = clientMapped;

                    _iAccountsRepository.AddAccount(accountMapped, true);
                }
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GenerateAccountNumber()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Second;
            int minutes = DateTime.Now.Second;
            int seconds = DateTime.Now.Second;

            string accountNumber = string.Empty;
            bool checkAccount = true;

            while (checkAccount)
            {
                accountNumber = $"{new Random().Next(0, 9)}{year}{month}{day}{hour}{minutes}{seconds}{new Random().Next(0, 9)}";

                Domains.Accounts.Accounts acc = GetAccount(accountNumber);

                if (acc == null)
                    checkAccount = false;
            }

            return accountNumber;
        }
    }
}