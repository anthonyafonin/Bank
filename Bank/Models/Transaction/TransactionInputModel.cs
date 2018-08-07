using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionInputModel
    {
        public Guid TransactionID { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        public Guid BankID { get; set; }
    }
}
