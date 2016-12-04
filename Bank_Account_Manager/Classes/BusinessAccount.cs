using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Manager.Classes
{
    class BusinessAccount : Account
    {
        public override int Balance { get; set; }

        public BusinessAccount()
        {
            Balance = 0;
        }
    }
}
