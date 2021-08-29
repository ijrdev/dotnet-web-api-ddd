using Domain.Responses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class DepositWithdrawTransactionsDTO
    {
        [Required(ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.REQUIRED_ACCOUNT_NUMBER)]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.REQUIRED_VALUE)]
        [Range(1, double.MaxValue, ErrorMessage = CustomResponseMessage.Accounts.DomainValidations.INVALID_VALUE)]
        public double Value { get; set; }
    }
}
