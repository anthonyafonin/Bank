using Bank.Models;
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
        // BankAccount properties
        private Guid BankID { get; set; }
        private List<Transaction> Transactions { get; set; }
        private Guid UserID { get; set; }

        // Constructor
        public BankAccount(BankAccountModel bank)
        {
            this.BankID = bank.BankID;
            this.Transactions = bank.Transactions;
            this.UserID = bank.UserID;
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
            return (depositBalance - withdrawBalance);
        }

        /// <summary>
        /// Makes a transaction of amount based on type
        /// </summary>
        /// <param name="type">Withdraw or Deposit</param>
        /// <param name="amount">Transaction Amount</param>
        public void MakeTransaction(TransactionRequestModel request)
        {
            Transactions.Add(new Transaction(new TransactionModel
            {
                TransactionID = Guid.NewGuid(),
                Type = request.Type,
                Created = DateTime.Now,
                Amount = request.Amount,
                BankID = this.BankID
            }));
        }

        /// <summary>
        /// Get list of transactions
        /// </summary>
        /// <returns>Returns Transaction list</returns>
        public List<Transaction> GetTransactionHistory() => Transactions;
    }
}
