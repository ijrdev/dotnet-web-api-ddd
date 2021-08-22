using AutoMapper;
using Domain.DTO;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Responses;
using CrossCutting;

namespace Services
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

        public Accounts GetAccount(string accountNumber)
        {
            return _iAccountsRepository.GetAccount(accountNumber);
        }

        public IEnumerable<Accounts> GetAccounts(long clientId)
        {
            return _iAccountsRepository.GetAccounts(clientId);
        }

        public void AddAccount(AccountClientDTO accountClient)
        {
            try
            {
                IMapper mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AccountClientDTO, Clients>();
                    cfg.CreateMap<AccountClientDTO, Accounts>();
                }).CreateMapper();

                Clients clientMapped = mapper.Map<Clients>(accountClient);
                Accounts accountMapped = mapper.Map<Accounts>(accountClient);

                if(!Enum.IsDefined(typeof(Genders), clientMapped.Gender))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INVALID_GENDER, clientMapped.Gender);

                if (!Enum.IsDefined(typeof(Persons), clientMapped.Person))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.INVALID_PERSON, clientMapped.Person);

                if (!Enum.IsDefined(typeof(AccountsType), accountMapped.AccountType))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.INVALID_ACCOUNT_TYPE, accountMapped.AccountType);

                Clients client = _iClientsService.GetClient(clientMapped.Document);

                if(client != null)
                {
                    IEnumerable<Accounts> accounts = GetAccounts((long) client.Id);

                    foreach(Accounts acc in accounts)
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

                    clientMapped.Password = Crypto.Password.Hash(clientMapped.Password);

                    accountMapped.Client = clientMapped;

                    _iAccountsRepository.AddAccount(accountMapped, true);
                }
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

                Accounts acc = GetAccount(accountNumber);

                if (acc == null)
                    checkAccount = false;
            }

            return accountNumber;
        }
    }
}