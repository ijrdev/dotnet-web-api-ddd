using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Services
{
    public class AccountsTransactionsService : IAccountsTransactionsService
    {
        private readonly IAccountsTransactionsRepository _iAccountsTransactionsRepository;
        private readonly IAccountsRepository _iAccountsRepository;

        public AccountsTransactionsService(IAccountsTransactionsRepository iAccountsTransactionsRepository, IAccountsRepository iAccountsRepository)
        {
            _iAccountsTransactionsRepository = iAccountsTransactionsRepository;
            _iAccountsRepository = iAccountsRepository;
        }

        public void Deposit(DepositWithdrawTransactionsDTO depositWithdrawTransaction)
        {
            try
            {
                Accounts account = _iAccountsRepository.GetAccount(depositWithdrawTransaction.AccountNumber);

                if (account == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND, new { depositWithdrawTransaction.AccountNumber });
                }

                account.Value = depositWithdrawTransaction.Value;

                _iAccountsRepository.UpdateAccount(account);

                Register(TransactionsType.Entry, Operation.Deposit, depositWithdrawTransaction.Value, account);
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

        public void Withdraw(long clientId, DepositWithdrawTransactionsDTO depositWithdrawTransaction)
        {
            try
            {
                Accounts account = _iAccountsRepository.GetAccount(depositWithdrawTransaction.AccountNumber);

                if (account == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND, new { depositWithdrawTransaction.AccountNumber });
                }

                if (account.Client.Id != clientId)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_DOES_NOT_BELONG_TO_USER);
                }

                if (account.Value < depositWithdrawTransaction.Value)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.INSUFFICIENT_VALUE, new { AccountValue = account.Value, WithdrawValue = depositWithdrawTransaction.Value });
                }

                account.Value = account.Value - depositWithdrawTransaction.Value;

                _iAccountsRepository.UpdateAccount(account);

                Register(TransactionsType.Output, Operation.Deposit, depositWithdrawTransaction.Value, account);
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

        public void Transfer(long clientId, TransferTransactionsDTO transferTransaction)
        {
            try
            {
                Accounts accountToTransfer = _iAccountsRepository.GetAccount(transferTransaction.AccountNumberToTransfer);
                Accounts accountToReceive = _iAccountsRepository.GetAccount(transferTransaction.AccountNumberToReceive);

                if (accountToTransfer != null && accountToReceive != null)
                {
                    if(accountToTransfer.Client.Id == clientId)
                    {
                        if (accountToTransfer.Value >= transferTransaction.Value)
                        {
                            accountToTransfer.Value = accountToTransfer.Value - transferTransaction.Value;

                            _iAccountsRepository.UpdateAccount(accountToTransfer);

                            Register(TransactionsType.Output, Operation.Transfer, transferTransaction.Value, accountToTransfer);

                            accountToReceive.Value = accountToReceive.Value + transferTransaction.Value;

                            _iAccountsRepository.UpdateAccount(accountToReceive);

                            Register(TransactionsType.Entry, Operation.Transfer, transferTransaction.Value, accountToReceive);
                        }
                        else
                        {
                            throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.INSUFFICIENT_VALUE, new { accountToTransfer.Value });
                        }
                    }
                    else
                    {
                        throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_DOES_NOT_BELONG_TO_USER);
                    }
                }
                else
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND);
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

        public AccountsStatementsDTO GetStatements(long clientId)
        {
            try
            {
                AccountsStatementsDTO accountsStatements = new AccountsStatementsDTO();

                Accounts account = _iAccountsRepository.GetAccount(clientId);

                if(account == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND);
                }

                IEnumerable<AccountsTransactions> accountTransactions = _iAccountsTransactionsRepository.GetStatements((long) account.Id);

                if(accountTransactions != null && accountTransactions.Count() > 0)
                {
                    IMapper mapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Accounts, AccountsStatementsDTO>();
                    }).CreateMapper();

                    AccountsStatementsDTO accountStatement = mapper.Map<AccountsStatementsDTO>(account);

                    accountStatement.AccountTransactions = accountTransactions;
                }

                return accountsStatements;
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

        private void Register(TransactionsType transactionsType, Operation operation, double value, Accounts account)
        {
            try 
            {
                AccountsTransactions accountTransaction = new AccountsTransactions();

                accountTransaction.TransactionType = (int) transactionsType;
                accountTransaction.Operation = (int) operation;
                accountTransaction.Value = value;
                accountTransaction.Account = account;

                _iAccountsTransactionsRepository.Register(accountTransaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
