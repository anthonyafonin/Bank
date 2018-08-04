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
        private Guid UserID { get; set; }
        private string UserPasswordHash { get; set; }
        private string UserPasswordSalt { get; set; }
        private Guid BankID { get; set; }
    }
}
