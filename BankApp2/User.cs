using System;
using static BankApp2.Program;

namespace BankApp2
{
        public class User
        {
            private string _name;
            public string name
            {
                get { return _name; }
                set { _name = value; }
            }

            private string _userName;
            public string userName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            private string _pinCode;
            public string pinCode
            {
                get { return _pinCode; }
                set { _pinCode = value; }
            }

            private Account[] _accounts;
            public Account[] accounts
            {
                get { return _accounts; }
                set { _accounts = value; }
            }

            //Creates new account with name and amount
            public void CreateAccount(string newAccountName, decimal depositAmount)
            {
                Account[] tempAccounts = _accounts;
                Array.Resize(ref tempAccounts, _accounts.Length + 1);
                accounts[_accounts.Length - 1] = new Account(newAccountName, depositAmount);
                return;
            }

            //Creates new account with name
            public void CreateAccount(string newAccountName)
            {
                Account[] tempAccounts = _accounts;
                Array.Resize(ref tempAccounts, _accounts.Length + 1);
                accounts[_accounts.Length - 1] = new Account(newAccountName);
                return;
            }

        }
    }


