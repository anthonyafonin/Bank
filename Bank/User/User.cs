using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UserNS
{
    public class User
    {
        // User Properties
        private Guid UserID { get; set; }
        private string Username { get; set; }
        private string UserPasswordHash { get; set; }
        private Guid BankID { get; set; }

        // Constructor
        public User(UserModel req)
        {
            UserID = req.UserID;
            Username = req.Username;
            UserPasswordHash = req.UserPasswordHash;
            BankID = req.BankID;
        }

        /// <summary>
        /// Get Username
        /// </summary>
        /// <returns>Username</returns>
        public string GetUsername() => Username;
    }
}
