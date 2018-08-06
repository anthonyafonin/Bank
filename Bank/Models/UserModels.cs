using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class UserModel
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string UserPasswordHash { get; set; }
        public Guid BankID { get; set; }
    }
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
