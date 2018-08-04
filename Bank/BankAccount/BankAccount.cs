using Bank.BankAccountNS;
using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BankAccountNS
{
    public class BankAccount : IBankAccount
    {
        private Guid BankID { get; set; }
        private List<Transaction> Transactions { get; set; }
        private Guid UserID { get; set; }

        public BankAccount(Guid UserID) {
            this.BankID = Guid.NewGuid();
            this.UserID = UserID;
        }

        /// <summary>
        /// Get available balance of the account.
        /// Subtract sum of withdraw values from sum of deposit values.
        /// </summary>
        /// <returns>Resturns available balance</returns>
        public double GetBalance()
        {
            double depositBalance = Transactions.Where(t => t.GetType() == TransactionType.Deposit).Sum(t => t.GetAmount());
            double withdrawBalance = Transactions.Where(t => t.GetType() == TransactionType.Withdraw).Sum(t => t.GetAmount());
            return depositBalance - withdrawBalance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        public void MakeTransaction(TransactionType type, double amount)
        {
            Transaction transaction = new Transaction(type, amount, BankID);
            Transactions.Add(transaction);
        }
    }
}
