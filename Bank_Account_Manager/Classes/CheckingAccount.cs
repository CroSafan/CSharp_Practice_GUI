using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Manager.Classes
{
    class CheckingAccount : Account
    {
        public override int Balance { get; set; }
        public CheckingAccount()
        {
            Balance = 0;
        }
    }
}
