using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankAccountNS;
using Bank.Models;
using Bank.TransactionNS;
using System.Collections.Generic;

namespace Bank.Tests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void DepositUpdatesBalance()
        {
            decimal balance = 0;
            decimal amount = (decimal)50.555555;
            decimal expected = balance + amount;

            BankAccount Account = new BankAccount(new BankAccountModel
            {
                BankID = Guid.NewGuid(),
                Transactions = new List<Transaction>(),
                UserID = Guid.NewGuid()
            });

            Account.MakeTransaction(new TransactionRequestModel
            {
                Type = TransactionType.Deposit,
                Amount = amount
            });

            Assert.AreEqual(expected, Account.GetBalance());
        }

        [TestMethod]
        public void WithdrawDoesNotUpdateBalance()
        {
            decimal balance = 0;
            decimal withdrawAmount = (decimal)50.555555;
            decimal expected = balance;

            BankAccount Account = new BankAccount(new BankAccountModel
            {
                BankID = Guid.NewGuid(),
                Transactions = new List<Transaction>(),
                UserID = Guid.NewGuid()
            });

            Account.MakeTransaction(new TransactionRequestModel
            {
                Type = TransactionType.Withdraw,
                Amount = withdrawAmount
            });

            Assert.AreNotEqual(expected, (Account.GetBalance() - withdrawAmount));
        }

        [TestMethod]
        public void WithdrawIsLessThanBalance()
        {
            decimal balance = 0;
            decimal amount = (decimal)50.555555;

            BankAccount Account = new BankAccount(new BankAccountModel
            {
                BankID = Guid.NewGuid(),
                Transactions = new List<Transaction>(),
                UserID = Guid.NewGuid()
            });

            Account.MakeTransaction(new TransactionRequestModel
            {
                Type = TransactionType.Withdraw,
                Amount = amount
            });

            bool expected = amount < balance;

            Assert.AreEqual(expected, amount < Account.GetBalance());
        }
    }
}
