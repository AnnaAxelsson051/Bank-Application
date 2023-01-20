using System;
namespace BankApp2
{
    public class Account
    {

        public Account(string accountName, decimal accountValue)
        {
            this.accountName = accountName;
            this.accountValue = accountValue;

        }

        public Account(string accountName)
        {
            this.accountName = accountName;

        }

        private string _accountName;
        public string accountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }

        private decimal _accountValue;
        public decimal accountValue
        {
            get { return _accountValue; }
            set { _accountValue = value; }
        }

    }
}

