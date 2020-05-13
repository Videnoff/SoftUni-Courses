using System;
using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private const int MIN_ID_VAL = 0;
        private const double MIN_AMOUNT_VAL = 0;

        private int id;
        private string @from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus transactionStatus, string @from, string to,  double amount)
        {
            this.Id = id;
            this.Status = transactionStatus;
            this.From = @from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get => this.id;

            set
            {
                if (value <= MIN_ID_VAL)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidMessage);
                }

                this.id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => this.@from;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSenderUsernameMessage);
                }

                this.@from = value;
            }
        }

        public string To
        {
            get => this.to;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidReceiverUsernameMessage);
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get => this.amount;

            set
            {
                if (value <= MIN_AMOUNT_VAL)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTransactionAmountMessage);
                }

                this.amount = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ITransaction transaction)
            {
                return this.Id == transaction.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}