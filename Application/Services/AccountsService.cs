using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Responses;

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

        public void AddAccount(long clientId, Accounts account)
        {
            try
            {
                if (!Enum.IsDefined(typeof(AccountsType), account.AccountType))
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.INVALID_ACCOUNT_TYPE, new { account.AccountType });

                Clients client = _iClientsService.GetClient(clientId);

                if(client == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND);
                }

                IEnumerable<Accounts> accounts = GetAccounts((long) client.Id);

                foreach (Accounts acc in accounts)
                {
                    if (acc.AccountType == account.AccountType)
                        throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_ALREADY_REGISTERED, new { account.AccountType });
                }

                account.AccountNumber = GenerateAccountNumber();
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