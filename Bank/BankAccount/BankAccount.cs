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
        public Guid BankID { get; }
        public List<Transaction> Transactions { get; }
        public Guid UserID { get; }

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
        public decimal GetBalance()
        {
            decimal depositBalance = Transactions.Where(t => t.Type == TransactionType.Deposit).Sum(t => t.Amount);
            decimal withdrawBalance = Transactions.Where(t => t.Type == TransactionType.Withdraw).Sum(t => t.Amount);
            return (depositBalance - withdrawBalance);
        }

        /// <summary>
        /// Makes a transaction of amount based on type
        /// </summary>
        /// <param name="type">Withdraw or Deposit</param>
        /// <param name="amount">Transaction Amount</param>
        public void MakeTransaction(TransactionRequestModel request)
        {
            Transactions.Add(new Transaction(new TransactionInputModel
            {
                TransactionID = Guid.NewGuid(),
                Type = request.Type,
                Created = DateTime.Now,
                Amount = request.Amount,
                BankID = this.BankID
            }));
        }
    }
}
