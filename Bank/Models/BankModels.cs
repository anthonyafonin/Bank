using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankAccountModel
    {
        public Guid BankID { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Guid UserID { get; set; }
    }
}
