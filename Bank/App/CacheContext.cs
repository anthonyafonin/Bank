using Bank.UserNS;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Bank.Models;

namespace Bank.AppNS
{
    /// <summary>
    /// Handles memory cache of available Users / BankAccounts
    /// </summary>
    public static class CacheContext
    {
        public static List<UserModel> Users = new List<UserModel>();
        public static List<BankAccountModel> BankAccounts = new List<BankAccountModel>();
    }
}
