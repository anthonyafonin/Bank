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
        public Guid UserID { get; }
        public string Username { get;}
        public string UserPasswordHash { get; }
        public Guid BankID { get; }

        // Constructors
        public User(UserModel req)
        {
            this.UserID = req.UserID;
            this.Username = req.Username;
            this.UserPasswordHash = req.UserPasswordHash;
            this.BankID = req.BankID;
        }
    }
}
