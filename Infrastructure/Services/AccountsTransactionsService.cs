using AutoMapper;
using Domain.Domain.Core.DTO;
using Domain.Domain.Core.Entities;
using Domain.Domain.Core.Enums;
using Domain.Domain.Core.Exceptions;
using Domain.Domain.Core.Interfaces.Repositories;
using Domain.Domain.Core.Interfaces.Services;
using Domain.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Services.Core
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

        public async Task Deposit(DepositWithdrawTransactionsDTO depositWithdrawTransaction)
        {
            try
            {
                Accounts account = await _iAccountsRepository.GetAccount(depositWithdrawTransaction.AccountNumber);

                if (account == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND, new { depositWithdrawTransaction.AccountNumber });
                }

                account.Value = account.Value + depositWithdrawTransaction.Value;

                await _iAccountsRepository.UpdateAccount(account);

                await Register (TransactionsType.Entry, Operation.Deposit, depositWithdrawTransaction.Value, account);
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

        public async Task Withdraw(long clientId, DepositWithdrawTransactionsDTO depositWithdrawTransaction)
        {
            try
            {
                Accounts account = await _iAccountsRepository.GetAccount(depositWithdrawTransaction.AccountNumber);

                if (account == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND, new { depositWithdrawTransaction.AccountNumber });
                }

                if (account.Client.Id != clientId)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.ACCOUNT_DOES_NOT_BELONG_TO_USER);
                }

                if (account.Value < depositWithdrawTransaction.Value)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.INSUFFICIENT_VALUE, new { AccountValue = account.Value, WithdrawValue = depositWithdrawTransaction.Value });
                }

                account.Value = account.Value - depositWithdrawTransaction.Value;

                await _iAccountsRepository.UpdateAccount(account);

                await Register (TransactionsType.Output, Operation.Deposit, depositWithdrawTransaction.Value, account);
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

        public async Task Transfer(long clientId, TransferTransactionsDTO transferTransaction)
        {
            try
            {
                Accounts accountToTransfer = await _iAccountsRepository.GetAccount(transferTransaction.AccountNumberToTransfer);
                Accounts accountToReceive = await _iAccountsRepository.GetAccount(transferTransaction.AccountNumberToReceive);

                if (accountToTransfer != null && accountToReceive != null)
                {
                    if(accountToTransfer.Client.Id == clientId)
                    {
                        if (accountToTransfer.Value >= transferTransaction.Value)
                        {
                            accountToTransfer.Value = accountToTransfer.Value - transferTransaction.Value;

                            await _iAccountsRepository.UpdateAccount(accountToTransfer);

                            await Register (TransactionsType.Output, Operation.Transfer, transferTransaction.Value, accountToTransfer);

                            accountToReceive.Value = accountToReceive.Value + transferTransaction.Value;

                            await _iAccountsRepository.UpdateAccount(accountToReceive);

                            await Register(TransactionsType.Entry, Operation.Transfer, transferTransaction.Value, accountToReceive);
                        }
                        else
                        {
                            throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.INSUFFICIENT_VALUE, new { accountToTransfer.Value });
                        }
                    }
                    else
                    {
                        throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.ACCOUNT_DOES_NOT_BELONG_TO_USER);
                    }
                }
                else
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND);
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

        public async Task<AccountsStatementsDTO> GetStatements(long clientId)
        {
            try
            {
                AccountsStatementsDTO accountStatements = new AccountsStatementsDTO();

                Accounts account = await _iAccountsRepository.GetAccount(clientId);

                if(account == null)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, ResponseMessages.Accounts.ConditionValidations.ACCOUNT_NUMBER_WAS_NOT_FOUND);
                }

                IEnumerable<AccountsTransactions> accountTransactions = await _iAccountsTransactionsRepository.GetStatements((long) account.Id);

                if(accountTransactions != null && accountTransactions.Count() > 0)
                {
                    IMapper mapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Accounts, AccountsStatementsDTO>();
                    }).CreateMapper();

                    accountStatements = mapper.Map<AccountsStatementsDTO>(account);

                    accountStatements.AccountTransactions = accountTransactions;

                    return accountStatements;
                }

                return accountStatements;
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

        private async Task Register(TransactionsType transactionsType, Operation operation, double value, Accounts account)
        {
            try 
            {
                AccountsTransactions accountTransaction = new AccountsTransactions();

                accountTransaction.TransactionType = (int) transactionsType;
                accountTransaction.Operation = (int) operation;
                accountTransaction.Value = value;
                accountTransaction.Account = account;

                await _iAccountsTransactionsRepository.Register(accountTransaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
