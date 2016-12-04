using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Manager.Classes
{
    class SavingsAccount : Account
    {
        public override int Balance { get; set; }


        public SavingsAccount()
        {
            Balance = 0;
        }
    }
}
