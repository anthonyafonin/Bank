using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.TransactionNS
{
    public class Transaction
    {
        // Transaction properties
        private Guid TransactionID { get; set; }
        private TransactionType Type { get; set; }
        private DateTime Created { get; set; }
        private double Amount { get; set; }
        private Guid BankID { get; set; }

        // Constructor
        public Transaction(TransactionModel t) {
            this.TransactionID = t.TransactionID;
            this.Created = t.Created;
            this.Type = t.Type;
            this.Amount = t.Amount;
            this.BankID = t.BankID;
        }

        /// <summary>
        /// Get Type of Transaction
        /// </summary>
        /// <returns>TransactionType</returns>
        public new TransactionType GetType() => Type;

        /// <summary>
        /// Get Amount of Transaction
        /// </summary>
        /// <returns>Amount</returns>
        public double GetAmount() => Amount;

        /// <summary>
        /// Get Datetime of when transaction was created
        /// </summary>
        /// <returns>Created</returns>
        public DateTime GetCreated() => Created;
    }
}
