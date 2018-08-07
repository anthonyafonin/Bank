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
            decimal amount = (decimal)50.555555;
            Transaction transaction = new Transaction(new TransactionInputModel
            {
                Type = TransactionType.Deposit,
                Amount = amount
            });

            Assert.AreEqual(amount, transaction.Amount);
        }

        [TestMethod]
        public void GetTypeReturnsTransactionType()
        {
            decimal amount = (decimal)50.555555;
            Transaction transaction = new Transaction(new TransactionInputModel
            {
                Type = TransactionType.Deposit,
                Amount = amount
            });

            Assert.AreEqual(TransactionType.Deposit, transaction.Type);
        }
    }
}
