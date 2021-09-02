namespace Domain.Domain.Core.Entities
{
    public class AccountsTransactions
    {
        public long? Id { get; set; }

        public int TransactionType { get; set; }

        public int Operation { get; set; }

        public double Value { get; set; }

        public virtual Accounts Account { get; set; }
    }
}
