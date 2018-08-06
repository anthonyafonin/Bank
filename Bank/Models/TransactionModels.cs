using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionModel
    {
        public Guid TransactionID { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }
        public Guid BankID { get; set; }
    }

    public class TransactionRequestModel{
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
    }
}
