using Domain.Domain.Core.Responses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.Core.DTO
{
    public class DepositWithdrawTransactionsDTO
    {
        [Required(ErrorMessage = ResponseMessages.Accounts.DomainValidations.REQUIRED_ACCOUNT_NUMBER)]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = ResponseMessages.Accounts.DomainValidations.REQUIRED_VALUE)]
        [Range(1, double.MaxValue, ErrorMessage = ResponseMessages.Accounts.DomainValidations.INVALID_VALUE)]
        public double Value { get; set; }
    }
}
