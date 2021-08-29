using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Net;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Responses;

namespace Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _iAccountsRepository;
        private readonly IClientsRepository _iClientsRepository;

        public AccountsService(IAccountsRepository iAccountsRepository, IClientsRepository iClientsRepository)
        {
            _iAccountsRepository = iAccountsRepository;
            _iClientsRepository = iClientsRepository;
        }

        public Accounts GetAccount(string accountNumber)
        {
            return _iAccountsRepository.GetAccount(accountNumber);
        }

        public Accounts GetAccount(long clientId)
        {
            return _iAccountsRepository.GetAccount(clientId);
        }

        public void AddAccount(long clientId, Accounts account)
        {
            try
            {
                Clients client = _iClientsRepository.GetClient(clientId);

                if(client == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Clients.ConditionValidations.CLIENT_NOT_FOUND);
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