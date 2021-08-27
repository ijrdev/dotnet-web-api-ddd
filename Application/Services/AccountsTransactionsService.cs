using Domain.DTO;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Responses;
using System;
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
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_NUMBER_NOT_FOUND, new { depositWithdrawTransaction.AccountNumber });
                }

                account.Balance = depositWithdrawTransaction.Value;

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
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_NUMBER_NOT_FOUND, new { depositWithdrawTransaction.AccountNumber });
                }

                if (account.Client.Id != clientId)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.ACCOUNT_DOES_NOT_BELONG_TO_USER);
                }

                if (account.Balance < depositWithdrawTransaction.Value)
                {
                    throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.Accounts.ConditionValidations.INSUFFICIENT_BALANCE, new { account.Balance, depositWithdrawTransaction.Value });
                }

                account.Balance = account.Balance - depositWithdrawTransaction.Value;

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

        //public void Transfer(TransactionsDTO transaction)
        //{
        //    try
        //    {
        //        Accounts accountToTransfer = GetAccount(transaction.AccountNumberToTransfer);
        //        Accounts accountToReceive = GetAccount(transaction.AccountNumberToReceive);

        //        if (accountToTransfer != null && accountToReceive != null)
        //        {
        //            // tipo da transção para primeiro verificar o saldo
        //            // colocar o tipo da transação e a operação em TransactionsDTO

        //            switch ()
        //            {
        //                case
        //            }

        //            if (accountToTransfer.Balance >= transaction.Value)
        //            {
        //                // 
        //            }
        //            else
        //            {
        //                throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.AccountsTransactions.ConditionValidations.INSUFFICIENT_BALANCE, new { accountToTransfer.Balance });
        //            }
        //        }
        //        else
        //        {
        //            throw new CustomException(HttpStatusCode.PreconditionFailed, CustomResponseMessage.AccountsTransactions.ConditionValidations.ACCOUNT_NUMBER_NOT_FOUND, new { accountToTransfer, accountToReceive });
        //        }
        //    }
        //    catch (CustomException)
        //    {
        //        throw;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private void Register(TransactionsType transactionsType, Operation operation, double value, Accounts account)
        {
            try 
            {
                AccountsTransactions accountTransaction = new AccountsTransactions();

                accountTransaction.TransactionType = (int) operation;
                accountTransaction.Operation = (int) transactionsType;
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
