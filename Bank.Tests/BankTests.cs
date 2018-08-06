using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.BankAccountNS;
using Bank.Models;

namespace Bank.Tests
{
    [TestClass]
    public class BankTests
    {

        public static readonly BankAccount Account = new BankAccount(new BankAccountModel
        {

        });

        [TestMethod]
        public void DepositUpdatesBalance()
        {
            double balance = 0.0;
            double depositAmount = 50.55;
          
        }
    }
}
