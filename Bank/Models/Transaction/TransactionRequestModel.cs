﻿using Bank.TransactionNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionRequestModel
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
