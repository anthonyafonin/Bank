using Bank.Models;
using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BankAccountNS
{
    public interface IBankAccount
    {
        void MakeTransaction(TransactionType type, double amount);
        double GetBalance();
    }
}
