using Domain.Domain.Core.Interfaces.Repositories;
using Domain.Domain.Core.Interfaces.Services;
using System;
using System.Net;
using Domain.Domain.Core.Entities;
using Domain.Domain.Core.Exceptions;
using Domain.Domain.Core.Responses;
using System.Threading.Tasks;

namespace Infrastructure.Services.Core
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

        public async Task<Accounts> GetAccount(string accountNumber)
        {
            return await _iAccountsRepository.GetAccount(accountNumber);
        }

        public async Task<Accounts> GetAccount(long clientId)
        {
            return await _iAccountsRepository.GetAccount(clientId);
        }

        public async Task AddAccount(long clientId, Accounts account)
        {
            try
            {
                Clients client = await _iClientsRepository.GetClient(clientId);

                if(client == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Clients.ConditionValidations.CLIENT_NOT_FOUND);
                }

                account.AccountNumber = await GenerateAccountNumber();
                account.Client = client;

                await _iAccountsRepository.AddAccount(account);
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

        private async Task<string> GenerateAccountNumber()
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

                Accounts acc = await GetAccount(accountNumber);

                if (acc == null)
                    checkAccount = false;
            }

            return accountNumber;
        }
    }
}