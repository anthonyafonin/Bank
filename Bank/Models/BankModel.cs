using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class BankModel
    {
        public long BankID { get; set; }
        public double Balance { get; set; }
        public List<TransactionModel> Transactions { get; set; }
        public long UserID { get; set; }
    }
}
