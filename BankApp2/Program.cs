using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;
//using Internal;
using static BankApp2.Program;

//TODO Change getters and setters to private?

//TODO It's a good practice to create each new class in a different source file. In Visual Studio,
//you can right-click on the project, and select add class to add a new class in a new file.
//In Visual Studio Code, select File then New to create a new source file. In either tool, name
//the file to match the class: InterestEarningAccount.cs, LineOfCreditAccount.cs, and GiftCardAccount.cs.

//Lägg till funktionalitet så att användaren kan öppna nya konton. 
//Lägg till så att användaren kan sätta in pengar —lätt
//TODO Gör så att olika konton har olika valuta, inklusive att valuta omvandlas när pengar flyttas mellan dem. 
//TODO Lägg till så att användare kan flytta pengar sinsemellan, dvs mellan olika användare

//Lägg till så att om användaren skriver fel pinkod tre gånger stängs inloggning för den
//användaren av i tre minuter istället för att programmet måste starta om.

////TODO Lägg till så att saldon för alla konton för alla användare sparas mellan körningarna av programmet så att saldon inte återställs. —spara i fil



namespace BankApp2;
class Program
{

    static void Main(string[] args)
    {


        //create array of users

        User[] users = new User[]
        {
          new User
        {
            name = "Arvin",
            userName = "Arvin",
            pinCode = "1111",
            accounts = new Account[]
            {
            new Account("Lönekonto", 100),
            new Account("Sparkonto", 200)
            }
        },


        new User
        {
            name = "Billy",
            userName = "Billy",
            pinCode = "2222",
            accounts = new Account[]
        {
            new Account("Lönekonto", 100),
            new Account("Sparkonto", 200),
            new Account("Resekonto", 300)
        }
        },

            new User
            {
                name = "Camilla",
                userName = "Camilla",
                pinCode = "3333",
                accounts = new Account[]
        {
            new Account("Lönekonto", 100),
            new Account("Sparkonto", 200),
            new Account("Resekonto", 300),
            new Account("Välgörenhetskonto", 400)
        }

            },

            new User
            {
                name = "D",
                userName = "Daniel",
                pinCode = "4444",
                accounts = new Account[]
        {
            new Account("Lönekonto", 100),
            new Account("Sparkonto", 200),
            new Account("Resekonto", 300),
            new Account("Välgörenhetskonto", 400),
            new Account("Renoveringskonto", 500)
        }

            },


            new User
            {
                name = "E",
                userName = "Emily",
                pinCode = "5555",
                accounts = new Account[]
        {
            new Account("Lönekonto", 100),
            new Account("Sparkonto", 200),
            new Account("Resekonto", 300),
            new Account("Välgörenhetskonto", 400),
            new Account("Renoveringskonto", 500),
            new Account("Reparationskonto", 600),
        }
            }
        };





        logInMenu();

        void logInMenu()
        {
            Console.WriteLine("---------- Log in ----------");
            Console.WriteLine("Välkommen till login sidan");
            int userTries = 0;
            bool logInMenu = true;
            do
            {
                Console.WriteLine("Var god ange ditt användarnamn");
                string? userName = Console.ReadLine();
                Console.WriteLine("Var god ange din pinkod");
                string? userPinCode = Console.ReadLine();
                foreach (var user in users)
                {
                    if ((user.userName.Equals(userName)) && (user.pinCode.Equals(userPinCode)))
                    {
                        //Console.WriteLine(user.userName);
                        //Console.WriteLine(user.pinCode);
                        logInMenu = false;
                        mainMenu(user);
                    }
                }
                userTries++;
                if (userTries > 1)
                {
                    Environment.Exit(0);
                    //Console.WriteLine("Sleep for 3 minutes");
                    //Thread.Sleep(180000);
                }

            } while (logInMenu);

        }

        void mainMenu(User user)
        {
            Console.WriteLine("---------- Huvudmeny ----------");
            Console.WriteLine("Välkommen till huvudmenyn");
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Var god välj något av följande alternativ");
                Console.WriteLine();
                Console.WriteLine("1 Se konton och saldon");
                Console.WriteLine("2 Överföringar");
                Console.WriteLine("3 Överföringar till annan användare");
                Console.WriteLine("4 Ta ut pengar");
                Console.WriteLine("5 Sätta in pengar pengar");
                Console.WriteLine("6 Skapa nytt konto");
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
                        TransferFundsToDifferentUser(user);
                        break;
                    case "4":
                        WithdrawFunds(user);
                        break;
                    case "5":
                        DepositFunds(user);
                        break;
                    case "6":
                        CreateNewAccount(user);
                        break;
                    case "E":
                        Console.WriteLine("E har valts, du loggas nu ut");
                        mainMenu = false;
                        logInMenu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Var god ange antingen val 1-6 eller E och tryck enter");
                        break;

                }
            }
        }


        void ListAccounts(User user)
        {
            Console.WriteLine("Nedan listas alla dina konton");

            for (int i = 1; i < user.accounts.Length; i++)
            {
                Console.Write(++i + ". " + user.accounts[i].accountName + "\t");
                //increase with 1 to display tex 1 - 3
            }
            for (int i = 1; i < user.accounts.Length; i++)
            {
                Console.Write(user.accounts[i].accountValue + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        //Main method for fund transfer using 3 helper methods
        void TransferFunds(User user)
        {
            ListAccounts(user);
            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            int foundDepositAccount = SelectDepositAccount(user);

            MakeTransfer(foundWithdrawalAccount, foundDepositAccount, user);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        void MakeTransfer(int foundWithdrawalAccount, int foundDepositAccount, User user)
        {
            bool notSufficientFunds = true;
            do
            {
                Console.WriteLine("Var god ange den summa du önskar överföra");
                string? input = Console.ReadLine();
                decimal transferAmount = Int32.Parse(input);

                if (user.accounts[foundWithdrawalAccount].accountValue < transferAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(transferAmount), "Det finns inte tillräckligt med pengar " +
                        "på kontot du vill överföra ifrån");
                }
                else
                {
                    decimal depositAccountPostTransfer =
         user.accounts[foundWithdrawalAccount].accountValue + transferAmount;
                    decimal withdrawalAccountPostTransfer =
         user.accounts[foundWithdrawalAccount].accountValue - transferAmount;

                    Console.WriteLine("Du har nu överfört " + transferAmount + " kr från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    withdrawalAccountPostTransfer + " kr. Och på ditt " +
                    user.accounts[foundDepositAccount].accountName + " finns nu " +
                    depositAccountPostTransfer + " kr.");
                    Console.WriteLine();
                    Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                    Console.ReadLine();
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }



        int SelectWithdrawalAccount(User user)
        {
            Console.WriteLine("Var god välj ett konto mellan 1 - " + user.accounts.Length +
                " att flytta pengar ifrån");
            int foundWithdrawalAccount = 0;
            int withdrawalAccount = 0;
            bool inCorrectInput = true;
            do
            {
                string? input = Console.ReadLine();
                try
                {
                    withdrawalAccount = Int32.Parse(input);
                    inCorrectInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit ett oriktigt val. Var vänlig försök igen. " +
                        "Välj ett konto att ta ut pengar ifrån");
                }

            } while (inCorrectInput);

            withdrawalAccount = -1;
            foundWithdrawalAccount = FindWithdrawalAccount(withdrawalAccount, user);
            return foundWithdrawalAccount;
        }

        int SelectDepositAccount(User user)
        {
            Console.WriteLine("Var god välj ett konto mellan 1 - " + user.accounts.Length +
                  " att flytta pengar till");
            bool inCorrectInput2 = true;
            int depositAccount = 0;
            int foundDepositAccount = 0;
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
            depositAccount = -1;
            foundDepositAccount = FindDepositAccount(depositAccount, user);
            return foundDepositAccount;
        }


        int FindWithdrawalAccount(int withdrawalAccount, User user)
        {
            int selectedWithDrawalAccount = 0;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (withdrawalAccount == i)
                {
                    Console.WriteLine("Du har angett kontot " + user.accounts[i].accountName);
                    selectedWithDrawalAccount = i;
                }
            }
            return selectedWithDrawalAccount;
        }

        int FindDepositAccount(int depositAccount, User user)
        {
            int selectedDepositAccount = 0;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (depositAccount == i)
                {
                    Console.WriteLine("Du har angett kontot " + user.accounts[i].accountName);
                    selectedDepositAccount = i;
                }
            }
            return selectedDepositAccount;
        }

        //Main method for withdrawing funds using 3 helper methods

        void WithdrawFunds(User user)
        {
            TestUserPinCode(user);
            ListAccounts(user);
            int foundWithdrawalAccount = SelectWithdrawalAccount(user);

            MakeWithdrawal(foundWithdrawalAccount, user);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

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
                    Console.WriteLine(user.pinCode);
                    Console.WriteLine(userPinCode);
                    testPincode = false;
                }

                userTries++;
                if (userTries > 1)
                {
                    Console.WriteLine("Du har angett fel pinkod tre gånger, var god vänta 3 minuter innan du försöker igen");
                    Console.WriteLine("Sleep for 3 minutes");
                    Thread.Sleep(180000);
                }

            } while (testPincode);
            return;
        }



        void MakeWithdrawal(int foundWithdrawalAccount, User user)
        {
            bool notSufficientFunds = true;
            decimal withdrawalAmount = 0;
            do
            {
                Console.WriteLine("Var god ange den summa du önskar ta ut");
                try
                {
                    string? input = Console.ReadLine();
                    withdrawalAmount = Int32.Parse(input);
                    notSufficientFunds = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit en oriktig inmatning. Var vänlig ange den summa " +
                        "du önskar sätta in");
                }

                if (user.accounts[foundWithdrawalAccount].accountValue < withdrawalAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(withdrawalAmount), "Det finns inte tillräckligt med pengar " +
                        "på kontot du vill överföra ifrån");
                }
                else
                {
                    decimal withdrawalAccountPostTransfer =
         user.accounts[foundWithdrawalAccount].accountValue - withdrawalAmount;

                    Console.WriteLine("Du har nu tagit ut " + withdrawalAmount + " kr från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    withdrawalAccountPostTransfer + " kr.");
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }

        //Main method for depositing funds using 1 helper method

        void DepositFunds(User user)
        {
            TestUserPinCode(user);
            ListAccounts(user);
            int foundDepositAccount = SelectDepositAccount(user);

            MakeDeposit(foundDepositAccount, user);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }


        void MakeDeposit(int foundDepositAccount, User user)
        {
            Console.WriteLine("Var god ange den summa du önskar sätta in");
            bool inCorrectInput = true;
            decimal depositAmount = 0;
            do
            {
                string? input = Console.ReadLine();
                try
                {
                    depositAmount = Int32.Parse(input);
                    inCorrectInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit en oriktig inmatning. Var vänlig ange den summa " +
                        "du önskar sätta in");
                }

            } while (inCorrectInput);

            decimal depositAccountPostTransfer =
         user.accounts[foundDepositAccount].accountValue + depositAmount;

            Console.WriteLine("Du har nu satt in " + depositAmount + " kr på ditt " +
            user.accounts[foundDepositAccount].accountName + ". På det kontot finns nu " +
            depositAccountPostTransfer + " kr.");
            return;
        }



        //Main method for creating new accounts using 2 helper methods

        void CreateNewAccount(User user)
        {
            Console.WriteLine("Vad god ange namnet på det nya konto du vill skapa");
            string? newAccountName = Console.ReadLine();
            Console.WriteLine("Vill du sätta in en summa på kontot? Ja/Nej");
            string? input = Console.ReadLine();
            bool nonsuccessfulDeposit = true;
            if (input.Equals("Ja"))
            {
                do
                {
                    Console.WriteLine("Hur mycket vill du sätta in?");
                    try
                    {
                        string? inputAmount = Console.ReadLine();
                        decimal depositAmount = Int32.Parse(inputAmount);
                        nonsuccessfulDeposit = true;
                        Console.WriteLine("Ditt nya konto " + newAccountName + " har skapats och " +
                            " kr finns nu på detta konto");
                        CreateAccountWithNameAndSumb(user, newAccountName, depositAmount);
                    }
                    catch (InvalidDataException)
                    {
                        Console.WriteLine("Du har angett ett felaktigt värde, var god försök igen");
                    }
                } while (nonsuccessfulDeposit);
            }
            else if (input.Equals("Nej"))
            {
                Console.WriteLine("Ditt nya konto " + newAccountName + " har skapats");
                CreateAccountWithName(user, newAccountName);
            }
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        void CreateAccountWithNameAndSumb(User user, string newAccountName, decimal depositAmount)
        {

            user.accounts = new Account[]
            {
            new Account(newAccountName, depositAmount)
            };
            return;
        }


        void CreateAccountWithName(User user, string newAccountName)
        {

            user.accounts = new Account[]
            {
            new Account(newAccountName)
            };
            return;
        }


        void TransferFundsToDifferentUser(User user)
        {
            TestUserPinCode(user);
            ListAccounts(user);
            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            int receiverUserSelected = SelectReceiverUser();
            int receiverUserAccountSelected = SelectReceiverUserAccount(receiverUserSelected);

            MakeTransferOfFundsToDifferentUser(foundWithdrawalAccount, receiverUserSelected,
                receiverUserAccountSelected, user);

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        void MakeTransferOfFundsToDifferentUser(int foundWithdrawalAccount, int receiverUserSelected,
            int receiverUserAccountSelected, User user)
        { 
           bool notSufficientFunds = true;
            do
            {
                Console.WriteLine("Var god ange den summa du önskar överföra");
                string? input = Console.ReadLine();
                decimal transferAmount = Int32.Parse(input);

                if (user.accounts[foundWithdrawalAccount].accountValue < transferAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(transferAmount), "Det finns inte tillräckligt med pengar " +
                        "på kontot du vill överföra ifrån");
                }
                else
                {
                    decimal depositAccountPostTransfer =
         users[receiverUserSelected].accounts[receiverUserAccountSelected].accountValue + transferAmount;
                    decimal withdrawalAccountPostTransfer =
         user.accounts[foundWithdrawalAccount].accountValue - transferAmount;

                    Console.WriteLine("Du har nu överfört " + transferAmount + " kr från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    withdrawalAccountPostTransfer + " kr. Och på " +
                    users[receiverUserSelected].name + "s " + users[receiverUserSelected].accounts[receiverUserAccountSelected].accountName +
                    " finns nu " + depositAccountPostTransfer + " kr.");
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }


        int SelectReceiverUser()
        {
            int receiverUser = 0;
            Console.WriteLine("Var god välj vilken av följande användare du vill flytta pengar till");
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(++i + ". " + users[i].name);
            }
            Console.WriteLine();
            Console.WriteLine("Gör ditt val genom att skriva in en siffra mellan 1 - " + users.Length);
            string? input = Console.ReadLine();
            int selectedUserIndex = Int32.Parse(input);    //välja mottagare
            selectedUserIndex -= 1;
            for (int i = 0; i < users.Length; i++)    //Hitta mottagare
            {
                if (selectedUserIndex == i)
                {
                    receiverUser = i;
                }
            }
            return receiverUser;
        }

        int SelectReceiverUserAccount(int receiverUserSelected)
        {
            int receiverAccount = 0;
            Console.WriteLine("Du har valt att föra över pengar till ett av " + users[receiverUserSelected].name + "s konton");
            Console.WriteLine("Var god välj vilket av " + users[receiverUserSelected].name + "s konton du vill flytta " +
                "pengar till");
            for (int i = 0; i < users.Length; i++)              
            {
                Console.WriteLine(++i + ". " + users[receiverUserSelected].accounts);
            }
            string? input2 = Console.ReadLine();
            int selectedReceiverAccount = Int32.Parse(input2);      
            selectedReceiverAccount -= 1;
            for (int i = 0; i < users[receiverUserSelected].accounts.Length; i++)
            {
                if (selectedReceiverAccount == i)                 
                {
                    receiverAccount = i;
                    Console.WriteLine("Du har valt att föra över pengar till " + users[receiverUserSelected].name
                        + "s " + users[receiverUserSelected].accounts[receiverAccount].accountName + "s konton"); 
                }
            }
            return receiverAccount;
        }
    }
    


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
        public string accountName
        {
            get
            {
                return accountName;
            }
            set
            {
                this.accountName = accountName;
            }
        }

        public decimal accountValue
        {
            get
            {
                return accountValue;
            }
            set
            {
                this.accountValue = accountValue;
            }
        }
    }

    public class User
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string pinCode { get; set; }


        /*public string name
        {
        get
        {
            return name;
        }
        set
            {
                this.name = name;
            }
        }
        public string userName
        {
        get
        {
            return userName;
        }
        set
            {
                this.userName = userName;
            }
        }
        public string pinCode
        {
        get
        {
            return pinCode;
        }
        set
            {
                this.pinCode = pinCode;
            }
        }*/
        public Account[] accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                accounts = value;
            }
        }
    }
}
    





