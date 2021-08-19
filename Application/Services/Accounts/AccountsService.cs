using AutoMapper;
using CrossCutting;
using Domains.DTO;
using Interfaces.Repositories.Accounts;
using Interfaces.Services.Accounts;
using System;

namespace Services.Clients
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _iAccountsRepository;

        public AccountsService(IAccountsRepository iAccountsRepository)
        {
            _iAccountsRepository = iAccountsRepository;
        }

        public Domains.Accounts.Accounts GetAccount(string accountNumber)
        {
            return _iAccountsRepository.GetAccount(accountNumber);
        }

        public void AddAccount(AccountClientDTO accountClient)
        {
            try
            {
                IMapper mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<AccountClientDTO, Domains.Clients.Clients>();
                    cfg.CreateMap<AccountClientDTO, Domains.Accounts.Accounts>();
                }).CreateMapper();

                Domains.Clients.Clients client = mapper.Map<Domains.Clients.Clients>(accountClient);
                Domains.Accounts.Accounts account = mapper.Map<Domains.Accounts.Accounts>(accountClient);

                string accountNumber = string.Empty;

                bool checkAccount = true;

                while(checkAccount)
                {
                    accountNumber = GenerateAccountNumber();

                    Domains.Accounts.Accounts acc = GetAccount(accountNumber);

                    if (acc == null)
                        checkAccount = false;
                }

                // VERIFICAR CPF JÁ CADASTRADO?

                account.AccountNumber = accountNumber;
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

            return $"{new Random().Next(0, 9)}{year}{month}{day}{hour}{minutes}{seconds}{new Random().Next(0, 9)}";
        }
    }
}