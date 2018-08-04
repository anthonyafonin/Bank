using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.TransactionNS
{
    public class Transaction
    {
        private Guid TransactionID { get; set; }
        private TransactionType Type { get; set; }
        private DateTime Created { get; set; }
        private double Amount { get; set; }
        private Guid BankID { get; set; }

        public Transaction(TransactionType Type, double Amount, Guid BankID) {
            TransactionID = Guid.NewGuid();
            Created = DateTime.Now;
            this.Type = Type;
            this.Amount = Amount;
            this.BankID = BankID;
        }

        public double GetAmount() => Amount;
        public new TransactionType GetType() => Type;
    }
}
