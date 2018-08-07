using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BankAccountNS
{
    /// <summary>
    /// Defined interface contract of minimum BankAccount methods.
    /// </summary>
    public interface IBankAccount
    {
        decimal GetBalance();
        void MakeTransaction(TransactionRequestModel request);
    }
}
