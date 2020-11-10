using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group_IT_VM.Models
{
    public class Account
    {
        public double Balance { set; get; }

        public Account(double balance)
        {
            Balance = balance;
        }

        public Account()
        {
            Balance = 0;
        }
        public void updateBalance(double v) {
            Balance += v;
        }
    }
}