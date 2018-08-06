using System;
using Bank.Models;
using Bank.TransactionNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void GetAmountReturnsValue()
        {
            double amount = 50.55;
            Transaction transaction = new Transaction(new TransactionModel
            {
                Type = TransactionType.Deposit,
                Amount = amount
            });

            Assert.AreEqual(amount, transaction.GetAmount());
        }

        [TestMethod]
        public void GetTypeReturnsTransactionType()
        {
            double amount = 50.55;
            Transaction transaction = new Transaction(new TransactionModel
            {
                Type = TransactionType.Deposit,
                Amount = amount
            });

            Assert.AreEqual(TransactionType.Deposit, transaction.GetType());
        }
    }
}
