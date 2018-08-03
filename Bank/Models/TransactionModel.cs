using Bank.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionModel
    {
        public long TransactionID { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }
        public long BankID { get; set; }
    }
}
