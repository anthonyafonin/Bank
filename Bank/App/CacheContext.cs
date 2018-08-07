using Bank.UserNS;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Bank.Models;
using Bank.BankAccountNS;

namespace Bank.AppNS
{
    /// <summary>
    /// Handles memory cache of available Users / BankAccounts
    /// </summary>
    public static class CacheContext
    {
        public static Dictionary<string, UserModel> _users = new Dictionary<string, UserModel>();
        public static Dictionary<Guid, BankAccountModel> _bankAccounts = new Dictionary<Guid, BankAccountModel>();
    }
}
