using Bank.Models;
using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Transaction
    {
        // Transaction properties
        public Guid TransactionID { get; }
        public TransactionType Type { get; }
        public DateTime Created { get; }
        public decimal Amount { get; }
        public Guid BankID { get; }

        // Constructor
        public Transaction(TransactionInputModel t) {
            this.TransactionID = t.TransactionID;
            this.Created = t.Created;
            this.Type = t.Type;
            this.Amount = t.Amount;
            this.BankID = t.BankID;
        }
    }
}
