using Bank.BankAccountNS;
using Bank.Models;
using Bank.TransactionNS;
using Bank.UserNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.AppNS
{
    public sealed class App
    {
        // Singleton
        private static App _instance;
        private static readonly object sync = new object();
        private App() { }

        // App variables
        public bool LoggedIn { get; set; }
        public User CurrentUser { get; set; }
        public BankAccount CurrentBankAccount { get; set; }
        
        /// <summary>
        /// Get App singleton instance using Double-Checked locking to prevent thread locking
        /// </summary>
        /// <returns>Returns App instance</returns>
        public static App GetApp()
        {
            if (_instance == null)
            {
                lock (sync)
                {
                    if (_instance == null)
                    {
                        _instance = new App();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// Loops through list of available users and change current user to select user if credentials succeed
        /// </summary>
        /// <param name="request">Login request model</param>
        /// <returns>Returns log in success status</returns>
        public bool PerformLogin(LoginRequestModel request)
        {
            List<UserModel> users = CacheContext.Users;
            List<BankAccountModel> bankAccounts = CacheContext.BankAccounts;

            // loop through both users and bankAccounts to find matching objects of requested login form
            if (users != null)
            {
                foreach (UserModel user in users)
                {
                    // if username matches and hashed password matches, find and assign bank account to current instance
                    if (request.Username == user.Username && Crypto.GetHashSalt(request.Password) == user.UserPasswordHash)
                    {
                        foreach (BankAccountModel account in bankAccounts)
                        {
                            if(account.UserID == user.UserID)
                            {
                                _instance.CurrentUser = new User(user);
                                _instance.CurrentBankAccount = new BankAccount(account);
                                _instance.LoggedIn = true;

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Create new user if username does not exist and passwords meet requirements
        /// </summary>
        /// <param name="request">Register request model</param>
        /// <returns>Register success status</returns>
        public bool PerformRegister(RegisterRequestModel request)
        {
            if (request.Password != request.ConfirmPassword || request.Password.Length < 7)
            {
                return false;
            }

            List<UserModel> users = CacheContext.Users;

            if(users != null)
            {
                foreach (var item in users)
                {
                    if (request.Username == item.Username)
                    {
                        return false;
                    }
                }
            }

            // if we get here, create new user account and bank account
            Guid userId = Guid.NewGuid();
            Guid bankId = Guid.NewGuid();

            // add bank to memory cache, use as active bank account
            BankAccountModel bankRequest = new BankAccountModel
            {
                BankID = bankId,
                Transactions = new List<Transaction>(),
                UserID = userId
            };

            CacheContext.BankAccounts.Add(bankRequest);
            _instance.CurrentBankAccount = new BankAccount(bankRequest);

            // add user to memory cache, use as active user
            UserModel userRequest = new UserModel
            {
                UserID = userId,
                Username = request.Username,
                UserPasswordHash = Crypto.GetHashSalt(request.Password),
                BankID = bankId
            };

            CacheContext.Users.Add(userRequest);
            _instance.CurrentUser = new User(userRequest);

            _instance.LoggedIn = true;

            return true;
        }

        /// <summary>
        /// Log out current user
        /// </summary>
        public void PerformLogout()
        {
            _instance.CurrentBankAccount = null;
            _instance.CurrentUser = null;
            _instance.LoggedIn = false;
        }
    }
}
