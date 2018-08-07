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
            var success = false;

            // lookup user then login and locate assigned bank account if credentials match
            CacheContext._users.TryGetValue(request.Username, out User user);
            if (CheckLoginIsValid(user, request.Password))
            {
                CacheContext._bankAccounts.TryGetValue(user.BankID, out BankAccount bankAccount);

                _instance.CurrentUser = new User(user);
                _instance.CurrentBankAccount = new BankAccount(bankAccount);
                _instance.LoggedIn = true;
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Create new user if username does not exist and passwords meet requirements
        /// </summary>
        /// <param name="request">Register request model</param>
        /// <returns>Register success status</returns>
        public bool PerformRegister(RegisterRequestModel request)
        {
            var success = false;

            // Create new account if registration meets validation
            if(CheckRegisterIsValid(request.Username, request.Password, request.ConfirmPassword))
            {
                Guid userId = Guid.NewGuid();
                Guid bankId = Guid.NewGuid();

                BankAccountModel bankRequest = new BankAccountModel
                {
                    BankID = bankId,
                    Transactions = new List<Transaction>(),
                    UserID = userId
                };
                _instance.CurrentBankAccount = new BankAccount(bankRequest);
                CacheContext._bankAccounts.Add(bankRequest.BankID, _instance.CurrentBankAccount);

                UserModel userRequest = new UserModel
                {
                    UserID = userId,
                    Username = request.Username,
                    UserPasswordHash = Crypto.GetHashSalt(request.Password),
                    BankID = bankId
                };
                _instance.CurrentUser = new User(userRequest);
                CacheContext._users.Add(userRequest.Username, _instance.CurrentUser);

                _instance.LoggedIn = true;
                success = true;
            }
            return success;
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

        /// <summary>
        /// Check validity of registration. 
        /// Return false if username exists or password does not meet requirements.
        /// </summary>
        /// <param name="username">Desired username</param>
        /// <param name="password">Password</param>
        /// <param name="confirmPassword">Confirmed Password</param>
        /// <returns>Registration status</returns>
        public bool CheckRegisterIsValid(string username, string password, string confirmPassword)
        {
            return !(CacheContext._users.ContainsKey(username) || (password != confirmPassword || password.Length < 7));
        }

        /// <summary>
        /// Check if user exists and if password matches user's hashed password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLoginIsValid(User user, string password)
        {
            return user != null && Crypto.GetHashSalt(password) == user.UserPasswordHash;
        }
    }
}
