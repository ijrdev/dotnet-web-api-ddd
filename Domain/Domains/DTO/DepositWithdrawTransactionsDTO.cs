using Domain.Responses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class DepositWithdrawTransactionsDTO
    {
        [Required(ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.REQUIRED_ACCOUNT_NUMBER)]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.REQUIRED_VALUE)]
        [Range(1, double.MaxValue, ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.INVALID_VALUE)]
        public double Value { get; set; }
    }
}
