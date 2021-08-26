using Domain.Responses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class TransactionsDTO
    {
        [Required(ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.REQUIRED_ACCOUNT_NUMBER_TO_TRANSFER)]
        public string AccountNumberToTransfer { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.REQUIRED_ACCOUNT_NUMBER_TO_RECEIVE)]
        public string AccountNumberToReceive { get; set; }

        [Required(ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.REQUIRED_VALUE)]
        [Range(1, double.MaxValue, ErrorMessage = CustomResponseMessage.AccountsTransactions.DomainValidations.INVALID_VALUE)]
        public double Value { get; set; }
    }
}
