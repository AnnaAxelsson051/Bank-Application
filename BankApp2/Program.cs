using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security;
using System.Threading;

using static BankApp2.Program;


//TODO make it so that users own accounts are not listed when selecting other user to 
///
//TODO endast visa två decimaled vid utskrift
//TODO dölja pincode vid inlogg
//TODO vid 49 om hur man gör annan variant av sleep, ej ha sleep pga det påv alla anv 
//TODO 1000-3000 ord totalt i hela readmen? /
//TODO add commenst for each method and codebits whos purpouse is not obvious



namespace BankApp2;
class Program
{

    static void Main(string[] args)
    {


        //create users

        User[] users = new User[]
        {
          new User
        {
            name = "Arvin",
            userName = "Arvin",
            pinCode = "1111",
            accounts = new Account[]
            {
            new Account("Lönekonto", 101),
            new Account("Sparkonto", 201)
            }
        },


        new User
        {
            name = "Billy",
            userName = "Billy",
            pinCode = "2222",
            accounts = new Account[]
        {
            new Account("Lönekonto", 102),
            new Account("Sparkonto", 202),
            new Account("Resekonto", 302)
        }
        },

            new User
            {
                name = "Camilla",
                userName = "Camilla",
                pinCode = "3333",
                accounts = new Account[]
        {
            new Account("Lönekonto", 103),
            new Account("Sparkonto", 203),
            new Account("Resekonto", 303),
            new Account("Välgörenhetskonto", 403)
        }

            },

            new User
            {
                name = "Daniel",
                userName = "Daniel",
                pinCode = "4444",
                accounts = new Account[]
        {
            new Account("Lönekonto", 104),
            new Account("Sparkonto", 204),
            new Account("Resekonto", 304),
            new Account("Välgörenhetskonto", 404),
            new Account("Renoveringskonto", 504)
        }

            },


            new User
            {
                name = "Emily",
                userName = "Emily",
                pinCode = "5555",
                accounts = new Account[]
        {
            new Account("Lönekonto", 105),
            new Account("Sparkonto", 205),
            new Account("Resekonto", 305),
            new Account("Välgörenhetskonto", 405),
            new Account("Renoveringskonto", 505),
            new Account("Reparationskonto", 605),
        }
            }
        };



        //Loggs user into the bank, asks for user name and pincode - if correct redirects
        //user to MainMenu
        while (true)
        {
            Console.WriteLine("---------- Log in ----------");
            Console.WriteLine("Välkommen till login sidan");
            Console.WriteLine("Var god ange ditt användarnamn");
            bool inCorrectUserName = true;
            int userTries = 2;
            do
            {
                string? userName = Console.ReadLine();
                foreach (var user in users)
                {
                    if (string.Equals(user.userName, userName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Välkommen " + userName);
                        inCorrectUserName = false;
                        bool inCorrectPinCode = true;
                        Console.WriteLine("Var god ange din pinkod");
                        while (inCorrectPinCode)
                        {
                            string? userPinCode = Console.ReadLine();
                            if (user.pinCode.Equals(userPinCode))
                            {
                                Console.WriteLine(user.pinCode);
                                inCorrectPinCode = false;
                                userTries = 2;
                                MainMenu(user);
                            }
                            else if (!userPinCode.Equals(user.pinCode) && userTries > 0)
                            {
                                Console.WriteLine("Du har angett fel pinkod var god försök igen, du har " + userTries + " försök kvar");
                                userTries--;
                            }
                            else if (!userPinCode.Equals(user.pinCode) && userTries == 0)
                            {

                                Console.WriteLine("Du har angett fel pinkod tre gånger, var god vänta 3 minuter " +
                                    "innan du försöker igen");
                                Thread.Sleep(180000);
                            }
                        }
                    }
                }

            } while (inCorrectUserName);
        }

    


    //Lets user choose from a list of bank errands to execute
    //Or choose to log out and is then returned to log in

    void MainMenu(User user)
        {
            Console.WriteLine();
            Console.WriteLine("---------- Huvudmeny ----------");
            Console.WriteLine("Välkommen till huvudmenyn");
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Var god välj något av följande alternativ");
                Console.WriteLine();
                Console.WriteLine("1 Se konton och saldon");
                Console.WriteLine("2 Överföringar");
                Console.WriteLine("3 Ta ut pengar");
                Console.WriteLine("4 Sätta in pengar");
                Console.WriteLine("5 Skapa nytt konto");
                Console.WriteLine("6 Överföringar till annan användare");
                Console.WriteLine("E Exit");
                string? choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "1":
                        ListAccounts(user);
                        break;
                    case "2":
                        TransferFunds(user);
                        break;
                    case "3":
                        WithdrawFunds(user);
                        break;
                    case "4":
                        DepositFunds(user);
                        break;
                    case "5":
                        CreateNewAccount(user);
                        break;
                    case "6":
                        TransferFundsToDifferentUser(user);        
                        break;
                    case "E":
                        Console.WriteLine("E har valts, du loggas nu ut");
                        mainMenu = false;

                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Var god ange antingen val 1-6 eller E och tryck enter");
                        break;

                }
            }
        }

        //Lists user accounts with name, sumb and currency 
       void ListAccounts(User user)
        {
            Console.WriteLine("Nedan listas alla dina konton");
            int counter = 1;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (user.accounts[i].accountName.Equals("Resekonto"))
                {
                    Console.Write(counter + ". " + user.accounts[i].accountName + "\n");
                    Console.Write(user.accounts[i].accountValue + " euro\n");
                }
                else
                {
                    Console.Write(counter + ". " + user.accounts[i].accountName + "\n");
                    Console.Write(user.accounts[i].accountValue + " kr\n");
                }
                counter++;
            }
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        /****** Tansfer Section *******/
        //Handles transactions between users own accounts

        //Displays available accounts for transfer 
        void ListAccountsForTransfer(User user)
        {
            Console.WriteLine("Nedan listas alla dina konton");
            int counter = 1;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (user.accounts[i].accountName.Equals("Resekonto"))
                {
                    Console.Write(counter + ". " + user.accounts[i].accountName + "\n");
                    Console.Write(user.accounts[i].accountValue + " euro\n");
                }
                else
                {
                    Console.Write(counter + ". " + user.accounts[i].accountName + "\n");
                    Console.Write(user.accounts[i].accountValue + " kr\n");
                }
                counter++;
            }
        }


        //Main method for organizing fund transfer using 5 helper methods
        void TransferFunds(User user)
        {
            ListAccountsForTransfer(user);
            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            int foundDepositAccount = SelectDepositAccount(user);
            decimal transferAmount = GetTransferAmount();

            MakeTransfer(foundWithdrawalAccount, foundDepositAccount, transferAmount, user);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        //Lets user select withdrawal account and returns its ID
        int SelectWithdrawalAccount(User user)
        {
            Console.WriteLine("Var god välj ett konto mellan 1 - " + user.accounts.Length +
                " att flytta pengar ifrån");
            int withdrawalAccount = 0;
            bool inCorrectInput = true;
            do
            {
                string? input = Console.ReadLine();
                try
                {
                    withdrawalAccount = int.Parse(input);
                    inCorrectInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit ett oriktigt val. Var vänlig försök igen. " +
                        "Välj ett konto att ta ut pengar ifrån");
                }

            } while (inCorrectInput);

            withdrawalAccount -= 1;
            return withdrawalAccount;
        }

        //Lets user select deposit account and returns its ID
        int SelectDepositAccount(User user)
        {
            Console.WriteLine("Var god välj ett konto mellan 1 - " + user.accounts.Length +
                  " att flytta pengar till");
            bool inCorrectInput2 = true;
            int depositAccount = 0;
            do
            {
                string? input2 = Console.ReadLine();
                try
                {
                    depositAccount = Int32.Parse(input2);
                    inCorrectInput2 = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit ett oriktigt val. Var vänlig försök igen. " +
                        "Välj det konto du vill flytta pengarna till");
                }
            } while (inCorrectInput2);
            depositAccount -= 1;
            return depositAccount;
        }

        //Makes the actual transfer of funds
        void MakeTransfer(int foundWithdrawalAccount, int foundDepositAccount, decimal transferAmount, User user)
        {

            bool withdrawalAccountIsTravelAccount = CheckIfTravelAccount(foundWithdrawalAccount, user);
            bool depositAccountIsTravelAccount = CheckIfTravelAccount(foundDepositAccount, user);
            bool notSufficientFunds = true;
            decimal transferAmountPreConversion = 0;
            do
            {
                if (user.accounts[foundWithdrawalAccount].accountValue < transferAmount)
                {
                    Console.WriteLine("Du har angett en summa som är högre än den som finns på kontot, kontrollera ditt" +
                        "saldo och ange en ny summa");
                    string input = Console.ReadLine();
                    transferAmount = decimal.Parse(input);
                    transferAmountPreConversion = transferAmount;
                    Console.WriteLine();
                }
                else
                {
                    transferAmountPreConversion = transferAmount;
                    string depositAccountCurrency = "";
                    string withdrawalAccountCurrency = "";
                    if (withdrawalAccountIsTravelAccount && !depositAccountIsTravelAccount)
                    {
                        transferAmount *= (decimal)11.20;
                        withdrawalAccountCurrency = "euro";
                        depositAccountCurrency = "kr";
                    }
                    if (depositAccountIsTravelAccount && !withdrawalAccountIsTravelAccount)
                    {
                        transferAmount /= (decimal)11.20;
                        withdrawalAccountCurrency = "kr";
                        depositAccountCurrency = "euro";
                    }
                    if (depositAccountIsTravelAccount && withdrawalAccountIsTravelAccount)
                    {
                        withdrawalAccountCurrency = "euro";
                        depositAccountCurrency = "euro";
                    }
                    if (!depositAccountIsTravelAccount && !withdrawalAccountIsTravelAccount)
                    {
                        withdrawalAccountCurrency = "kr";
                        depositAccountCurrency = "kr";
                    }
                    user.accounts[foundDepositAccount].accountValue += transferAmount;
                    user.accounts[foundWithdrawalAccount].accountValue -= transferAmountPreConversion;
                    Console.WriteLine("Du har nu överfört " + transferAmountPreConversion + " " + withdrawalAccountCurrency + " från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    user.accounts[foundWithdrawalAccount].accountValue + " " + withdrawalAccountCurrency + " Och på ditt " +
                    user.accounts[foundDepositAccount].accountName + " finns nu " +
                    user.accounts[foundDepositAccount].accountValue + " " + depositAccountCurrency);
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }



        //Lets user choose a transfer amount and returns it
        decimal GetTransferAmount()
        {
            decimal transferAmount = 0;
            bool invalidTransferAmount = true;
            do
            {
                try
                {
                    Console.WriteLine("Var god ange önskad summa");
                    string? input = Console.ReadLine();
                    transferAmount = decimal.Parse(input);
                    invalidTransferAmount = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha gjort en oriktig inmatning. Var vänlig försök igen.");
                }
            } while (invalidTransferAmount);
            return transferAmount;
        }

        //Validates user pin code
        void TestUserPinCode(User user)
        {
            int userTries = 0;
            bool testPincode = true;
            do
            {
                Console.WriteLine("Var god ange din pinkod");
                string? userPinCode = Console.ReadLine();

                if (user.pinCode.Equals(userPinCode))
                {
                    testPincode = false;
                }
                userTries++;
                if (userTries > 2)
                {
                    Console.WriteLine("Du har angett fel pinkod tre gånger, var god vänta 3 minuter innan du försöker igen");
                    Thread.Sleep(180000);
                }
            } while (testPincode);
            return;
        }

        //Checks if account is "Resekonto" and returns a bool 
        bool CheckIfTravelAccount(int account, User user)
        {
            bool travelAccount = false;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (user.accounts[account].accountName.Equals("Resekonto"))
                {
                    travelAccount = true;
                }
                else
                {
                    travelAccount = false;
                }
            }
            return travelAccount;
        }

        /******** Withdrawal Section **********/


        //Main method for organizing withdrawals using 6 helper methods
        void WithdrawFunds(User user)
        {
            ListAccountsForTransfer(user);

            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            decimal transferAmount = GetTransferAmount();

            TestUserPinCode(user);
            bool isTravelAccount = CheckIfTravelAccount(foundWithdrawalAccount, user);

            MakeWithdrawal(foundWithdrawalAccount, isTravelAccount, transferAmount, user);

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        //Makes the actual withdrawal 
        void MakeWithdrawal(int foundWithdrawalAccount, bool isTravelAccount, decimal transferAmount, User user)
        {
            bool notSufficientFunds = true;
            do
            {
                if (user.accounts[foundWithdrawalAccount].accountValue < transferAmount)
                {
                    Console.WriteLine("Du har angett en summa som är högre än den som finns på kontot, kontrollera ditt" +
                        "saldo och ange en ny summa");
                    string input = Console.ReadLine();
                    transferAmount = decimal.Parse(input);
                    Console.WriteLine();
                }
                else
                {
                    string currency = "kr";
                    if (isTravelAccount)
                    {
                        currency = "euro";
                    }
                    user.accounts[foundWithdrawalAccount].accountValue -= transferAmount;

                    Console.WriteLine("Du har nu tagit ut " + transferAmount + " " + currency + " från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    user.accounts[foundWithdrawalAccount].accountValue + " " + currency);
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }

        /******* Deposit Section ********/

        //Main method for organizing deposits using 5 helper methods
        void DepositFunds(User user)
        {
            ListAccountsForTransfer(user);

            int foundDepositAccount = SelectDepositAccount(user);
            decimal transferAmount = GetTransferAmount();
            bool isTravelAccount = CheckIfTravelAccount(foundDepositAccount, user);

            MakeDeposit(foundDepositAccount, transferAmount, isTravelAccount, user);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        //Makes the actual deposit
        void MakeDeposit(int foundDepositAccount, decimal transferAmount, bool isTravelAccount, User user)
        {
            string currency = "kr";
            if (isTravelAccount)
            {
                currency = "euro";
            }
            user.accounts[foundDepositAccount].accountValue += transferAmount;

            Console.WriteLine("Du har nu satt in " + transferAmount + " " + currency + " på ditt " +
            user.accounts[foundDepositAccount].accountName + ". På det kontot finns nu " +
            user.accounts[foundDepositAccount].accountValue + " " + currency);
            return;
        }

        /********* Create Accounts Section ***********/

        //Main method for creating new accounts using 2 helper methods
        void CreateNewAccount(User user)
        {
            Console.WriteLine("Vad god ange namnet på det nya konto du vill skapa");
            string? newAccountName = Console.ReadLine();
            string userChoice = "";
            Console.WriteLine("Vill du sätta in en summa på kontot? Var god ange svar som Ja/Nej");
            bool nonValidInput = true;
            do
            {
                try
                {
                    userChoice = Console.ReadLine();
                    nonValidInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit en oriktig inmatning. Var vänlig ange Ja/Nej");
                }
            } while (nonValidInput);

            bool nonsuccessfulDeposit = true;
            if (string.Equals(userChoice, "Ja", StringComparison.OrdinalIgnoreCase))
            {
                do
                {
                    Console.WriteLine("Hur mycket vill du sätta in?");
                    string? inputAmount = Console.ReadLine();
                    try
                    {
                        decimal depositAmount = decimal.Parse(inputAmount);
                        nonsuccessfulDeposit = false;
                        user.CreateAccount(newAccountName, depositAmount);
                        Console.WriteLine("Ditt nya konto men namnet " + newAccountName + " har skapats och "
                            + inputAmount + " kr finns nu på detta konto");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Du har angett ett felaktigt värde, var god försök igen");
                    }
                } while (nonsuccessfulDeposit);
            }
            else if (string.Equals(userChoice, "Nej", StringComparison.OrdinalIgnoreCase))
            {
                user.CreateAccount(newAccountName);
                Console.WriteLine("Ditt nya konto med namnet " + newAccountName + " har skapats");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        /********** Transfers between users Section ************/

        //Main method for organizing transfers between users using 7 helper methods
        void TransferFundsToDifferentUser(User user)
        {
            ListAccountsForTransfer(user);

            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            int foundReceiverUser = SelectReceiverUser();
            int foundReceiverUserAccount = SelectReceiverUserAccount(foundReceiverUser);
            decimal transferAmount = GetTransferAmount();
            TestUserPinCode(user);

            MakeTransferOfFundsToDifferentUser(foundWithdrawalAccount, foundReceiverUser, foundReceiverUserAccount,
                 transferAmount, user);

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }



        //Let's user select user to transfer funds to and returns its ID
        int SelectReceiverUser()
        {
            Console.WriteLine("Var god välj vilken av följande användare du vill flytta pengar till");
            int counter = 1;
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(counter + ". " + users[i].name);
                counter++;
            }
            Console.WriteLine();
            Console.WriteLine("Gör ditt val genom att skriva in en siffra mellan 1 - " + users.Length);
            string? input = Console.ReadLine();
            int selectedUserIndex = Int32.Parse(input);
            selectedUserIndex -= 1;
            return selectedUserIndex;
        }

        //Let's user select user account to transfer funds to and returns its ID
        int SelectReceiverUserAccount(int foundReceiverUser)
        {
            int receiverAccount = 0;
            Console.WriteLine("Du har valt att föra över pengar till ett av " + users[foundReceiverUser].name + "s konton");
            Console.WriteLine("Var god välj vilket konto du vill flytta pengarna till");
            int counter = 1;
            for (int i = 0; i < users[foundReceiverUser].accounts.Length; i++)
            {
                if (users[foundReceiverUser].accounts[i].accountName.Equals("Resekonto"))
                {
                    Console.Write(counter + ". " + users[foundReceiverUser].accounts[i].accountName + "\n");
                    Console.Write(users[foundReceiverUser].accounts[i].accountValue + " euro\n");
                }
                else
                {
                    Console.Write(counter + ". " + users[foundReceiverUser].accounts[i].accountName + "\n");
                    Console.Write(users[foundReceiverUser].accounts[i].accountValue + " kr\n");
                }
                counter++;
            }

            string? input2 = Console.ReadLine();
            int selectedReceiverAccount = Int32.Parse(input2);
            selectedReceiverAccount -= 1;
            Console.WriteLine("Du har valt att föra över pengar till " + users[foundReceiverUser].name
                        + "s " + users[foundReceiverUser].accounts[selectedReceiverAccount].accountName);
            return selectedReceiverAccount;
        }

        //Makes the actual transfer of funds to different user account, converts currency
        void MakeTransferOfFundsToDifferentUser(int foundWithdrawalAccount, int foundReceiverUser,
            int foundReceiverUserAccount, decimal transferAmount, User user)
        {
            bool notSufficientFunds = true;
            decimal transferAmountPreConversion = transferAmount;
            do
            {
                if (user.accounts[foundWithdrawalAccount].accountValue < transferAmount)
                {
                    Console.WriteLine("Du har angett en summa som är högre än den som finns på kontot, kontrollera ditt" +
                        "saldo och ange en ny summa");
                    string input = Console.ReadLine();
                    transferAmount = decimal.Parse(input);
                    transferAmountPreConversion = transferAmount;
                    Console.WriteLine();
                }
                else
                {
                    string depositAccountCurrency = "";
                    string withdrawalAccountCurrency = "";
                    if (("Resekonto").Equals(user.accounts[foundWithdrawalAccount].accountName) &&
                        !("Resekonto").Equals(users[foundReceiverUser].accounts[foundReceiverUserAccount].accountName))
                    {
                        transferAmount *= (decimal)11.20;
                        withdrawalAccountCurrency = "euro";
                        depositAccountCurrency = "kr";
                    }
                    if (("Resekonto").Equals(users[foundReceiverUser].accounts[foundReceiverUserAccount].accountName) &&
                        !("Resekonto").Equals(user.accounts[foundWithdrawalAccount].accountName))

                    {
                        transferAmount /= (decimal)11.20;
                        withdrawalAccountCurrency = "kr";
                        depositAccountCurrency = "euro";
                    }
                    if (("Resekonto").Equals(users[foundReceiverUser].accounts[foundReceiverUserAccount].accountName) &&
                        ("Resekonto").Equals(user.accounts[foundWithdrawalAccount].accountName))
                    {
                        withdrawalAccountCurrency = "euro";
                        depositAccountCurrency = "euro";
                    }
                    if (!("Resekonto").Equals(users[foundReceiverUser].accounts[foundReceiverUserAccount].accountName) &&
                        !("Resekonto").Equals(user.accounts[foundWithdrawalAccount].accountName))

                    {
                        withdrawalAccountCurrency = "kr";
                        depositAccountCurrency = "kr";
                    }

                    users[foundReceiverUser].accounts[foundReceiverUserAccount].accountValue += transferAmount;
                    user.accounts[foundWithdrawalAccount].accountValue -= transferAmountPreConversion;

                    Console.WriteLine("Du har nu överfört " + transferAmountPreConversion + " " + withdrawalAccountCurrency + " från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    user.accounts[foundWithdrawalAccount].accountValue + " " + withdrawalAccountCurrency + ". Och på " +
                    users[foundReceiverUser].name + "s " + users[foundReceiverUser].accounts[foundReceiverUserAccount].accountName +
                    " finns nu " + users[foundReceiverUser].accounts[foundReceiverUserAccount].accountValue + " " + depositAccountCurrency);
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }
    }
}