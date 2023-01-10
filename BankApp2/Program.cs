using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;
//using Internal;
using static BankApp2.Program;

//TODOChange getters and setters to private?

//TODO It's a good practice to create each new class in a different source file. In Visual Studio,
//you can right-click on the project, and select add class to add a new class in a new file.
//In Visual Studio Code, select File then New to create a new source file. In either tool, name
//the file to match the class: InterestEarningAccount.cs, LineOfCreditAccount.cs, and GiftCardAccount.cs.

//TODO make it so that users own accounts are not listed when selecting other user to 

//Lägg till så att om användaren skriver fel pinkod tre gånger stängs inloggning för den
//användaren av i tre minuter istället för att programmet måste starta om.

////TODO Lägg till så att saldon för alla konton för alla användare sparas mellan körningarna
///av programmet så att saldon inte återställs. —spara i fil



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
            new Account("Resekonto", 300)      //with euros?
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

        /*
        LogInMenu();

        void LogInMenu()
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
                    if (string.Equals(user.userName, userName, StringComparison.OrdinalIgnoreCase) && user.pinCode.Equals(userPinCode))
                    
                    {
                        //Console.WriteLine(user.userName);
                        //Console.WriteLine(user.pinCode);
                        logInMenu = false;
                        MainMenu(user);
                    }
                }
                userTries++;
                if (userTries > 2)
                {
                    Environment.Exit(0);
                    //Console.WriteLine("Sleep for 3 minutes");
                    //Thread.Sleep(180000);
                }

            } while (logInMenu);

        }*/


        /*LogInMenu();

        void LogInMenu()
        {
            Console.WriteLine("---------- Log in ----------");
            Console.WriteLine("Välkommen till login sidan");
            Console.WriteLine("Var god ange ditt användarnamn");
            bool inCorrectUserName = true;
            //while (logInMenu) {
            int userIndex = 0;
            do
            {
                string? userName = Console.ReadLine();
                for (int i = 0; i<users.Length; i++)
                {
                    if (string.Equals(users[i].userName, userName, StringComparison.OrdinalIgnoreCase))
                        userIndex = i;
                    {
                        Console.WriteLine("Välkommen " + userName);
                        inCorrectUserName = false;
                        Console.WriteLine("Var god ange din pinkod");
                        string? userPinCode = Console.ReadLine();
                        bool inCorrectPinCode = true;
                        int userTries = 0;
                        while (inCorrectPinCode)
                        {
                            if (users[userIndex].pinCode.Equals(userPinCode))
                            {
                                Console.WriteLine(users[userIndex].pinCode);
                                inCorrectPinCode = false;
                                MainMenu(user);
                            }
                            if (!user.pinCode.Equals(userPinCode) && userTries < 3)
                            {
                                Console.WriteLine("Du har angett fel pinkod var god försök igen");
                                userTries++;
                            }
                            if (!user.pinCode.Equals(userPinCode) && userTries > 1)
                            {
                                Console.WriteLine("Du har angett fel pinkod tre gånger, programmet stängs av");
                                Thread.Sleep(3000);
                                Environment.Exit(0);
                                //Console.WriteLine("Du har angett fel pinkod tre gånger, var god vänta 3 minuter
                                //innan du försöker igen");
                                //Console.WriteLine("Sleep for 3 minutes");
                                //Thread.Sleep(180000);.
                            }
                            else if (!user.userName.Equals(userName))
                            {
                                Console.WriteLine("Du måste ha angett ett användarnamn som inte finns, var god försök igen");
                            }
                        }
                    }
                }
                
            } while (inCorrectUserName);
        } 
        */

        LogInMenu();
        void LogInMenu()
        {
            Console.WriteLine("---------- Log in ----------");
            Console.WriteLine("Välkommen till login sidan");
            Console.WriteLine("Var god ange ditt användarnamn");
            bool inCorrectUserName = true;
            int userTries = 0;
            do
            {
                string? userName = Console.ReadLine();
                //
                foreach (var user in users)
                {
                    if (string.Equals(user.userName, userName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Välkommen " + userName);
                        inCorrectUserName = false;
                        Console.WriteLine("Var god ange din pinkod");
                        string? userPinCode = Console.ReadLine();
                        if (user.pinCode.Equals(userPinCode))
                        {
                            Console.WriteLine(user.pinCode);
                            MainMenu(user);
                        }
                        if (userTries < 3 && !userPinCode.Equals(user.pinCode))
                        {
                            Console.WriteLine("Du har angett fel pinkod var god försök igen");
                            userTries++;
                        }
                        if (userTries > 2 && !userPinCode.Equals(user.pinCode))
                        { 
                            Console.WriteLine("Du har angett fel pinkod tre gånger, programmet stängs av");
                            Thread.Sleep(3000);
                            Environment.Exit(0);
                            //Console.WriteLine("Du har angett fel pinkod tre gånger, var god vänta 3 minuter
                            //innan du försöker igen");
                            //Console.WriteLine("Sleep for 3 minutes");
                            //Thread.Sleep(180000);.
                        }
                    }
                }
            
            } while (inCorrectUserName);
        }
                



        void MainMenu(User user)
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
                Console.WriteLine("5 Sätta in pengar");
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
                        LogInMenu();
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

        /****** Tansfer Section *******/

        //Main method for fund transfer using 3 helper methods

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

        //Enables user to select index for withdrawal account using 1 helper method:

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
            foundWithdrawalAccount = FindWithdrawalAccount(withdrawalAccount, user);
            return foundWithdrawalAccount;
        }

        //Loops to find the withdrawal account from the accounts array:

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

        //Enables user to select index for withdrawal account using 1 helper method:

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
            depositAccount -=1;
            foundDepositAccount = FindDepositAccount(depositAccount, user);
            return foundDepositAccount;
        }

        //Loops to find the deposit account from the accounts array:

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

        //Makes the actual transfer of funds:

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
                    /*throw new ArgumentOutOfRangeException(nameof(transferAmount), "Det finns inte tillräckligt med pengar " +
                        "på kontot du vill överföra ifrån");*/
                    Console.WriteLine("Du har angett en summa som är högre än den som finns på kontot, kontrollera ditt" +
                        "saldo och ange en ny summa");
                    //string input = Console.ReadLine();
                    //transferAmount = decimal.Parse(input);


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
                    /*Console.WriteLine();
                    Console.WriteLine("Tryck enter för att komma till huvudmenyn");
                    Console.ReadLine();*/
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }



      

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
                    //Console.WriteLine(user.pinCode);
                    //Console.WriteLine(userPinCode);
                    testPincode = false;
                }
                userTries++;
                if (userTries > 2)
                {
                    Console.WriteLine("Du har angett fel pinkod tre gånger, var god vänta 3 minuter innan du försöker igen");
                    //Console.WriteLine("Sleep for 3 minutes");
                    Thread.Sleep(180000);
                }

            } while (testPincode);
            return;
        }

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

        //Main method for withdrawing funds using 3 helper methods

        void WithdrawFunds(User user)
        {
            TestUserPinCode(user);
            ListAccountsForTransfer(user);

            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            decimal transferAmount = GetTransferAmount();
            bool isTravelAccount = CheckIfTravelAccount(foundWithdrawalAccount, user);

            MakeWithdrawal(foundWithdrawalAccount, isTravelAccount, transferAmount, user);

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }


        void MakeWithdrawal(int foundWithdrawalAccount, bool isTravelAccount, decimal transferAmount, User user)
        {
            bool notSufficientFunds = true;
            do
            {

                if (user.accounts[foundWithdrawalAccount].accountValue < transferAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(transferAmount), "Det finns inte tillräckligt med pengar " +
                        "på kontot du vill överföra ifrån");
                }
                else
                {
                    string currency = "kr";
                    if (isTravelAccount)
                    {
                        currency = "euro";
                    }
                    decimal withdrawalAccountPostTransfer =
         user.accounts[foundWithdrawalAccount].accountValue - transferAmount;

                    Console.WriteLine("Du har nu tagit ut " + transferAmount + " " + currency + " från ditt " +
                    user.accounts[foundWithdrawalAccount].accountName + ". Kvar på det kontot finns nu " +
                    withdrawalAccountPostTransfer + " " + currency);
                    notSufficientFunds = false;
                }
            } while (notSufficientFunds);
            return;
        }

        /******* Deposit Section ********/

        //Main method for depositing funds using 1 helper method

        void DepositFunds(User user)
        {
            //TestUserPinCode(user);
            ListAccountsForTransfer(user);

            int foundDepositAccount = SelectDepositAccount(user);
            decimal transferAmount = GetTransferAmount();
            bool isTravelAccount = CheckIfTravelAccount(foundDepositAccount, user);


            MakeDeposit(foundDepositAccount, transferAmount, isTravelAccount, user);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }


        void MakeDeposit(int foundDepositAccount, decimal transferAmount, bool isTravelAccount, User user)
        {
            string currency = "kr";
            if (isTravelAccount)
            {
                currency = "euro";
            }
            decimal depositAccountPostTransfer =
         user.accounts[foundDepositAccount].accountValue + transferAmount;

            Console.WriteLine("Du har nu satt in " + transferAmount + " " + currency + " på ditt " +
            user.accounts[foundDepositAccount].accountName + ". På det kontot finns nu " +
            depositAccountPostTransfer + " " + currency);
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
            //string.Equals(val, "astringvalue",  StringComparison.OrdinalIgnoreCase)
            {
                do
                {
                    Console.WriteLine("Hur mycket vill du sätta in?");
                    string? inputAmount = Console.ReadLine();
                    try
                    {
                        decimal depositAmount = decimal.Parse(inputAmount);
                        nonsuccessfulDeposit = false;
                        CreateAccountWithNameAndSumb(user, newAccountName, depositAmount);
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
                CreateAccountWithName(user, newAccountName);
                Console.WriteLine("Ditt nya konto med namnet " + newAccountName + " har skapats");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }

        void CreateAccountWithNameAndSumb(User user, string newAccountName, decimal depositAmount)
        {
            Account[] tempAccounts = user.accounts;
            Array.Resize(ref tempAccounts, user.accounts.Length + 1);
            user.accounts[user.accounts.Length - 1] = new Account(newAccountName, depositAmount);

            return;
        }


        void CreateAccountWithName(User user, string newAccountName)
        {

            Account[] tempAccounts = user.accounts;
            Array.Resize(ref tempAccounts, user.accounts.Length + 1);
            user.accounts[user.accounts.Length - 1] = new Account(newAccountName);
            return;
        }

        /********** Transfers between users Section ************/

        void TransferFundsToDifferentUser(User user)
        {
            TestUserPinCode(user);
            ListAccountsForTransfer(user);
          
            //int foundDepositAccount = SelectDepositAccount(user);
            int foundWithdrawalAccount = SelectWithdrawalAccount(user);
            int foundReceiverUser = SelectReceiverUser();
            int foundReceiverUserAccount = SelectReceiverUserAccount(foundReceiverUser);
            decimal transferAmount = GetTransferAmount();

            MakeTransferOfFundsToDifferentUser(foundWithdrawalAccount, foundReceiverUser, foundReceiverUserAccount,
                 transferAmount, user);

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }
        //

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


        int SelectReceiverUser()
        {
            int receiverUser = 0;
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

        int SelectReceiverUserAccount(int foundReceiverUser)
        {
            int receiverAccount = 0;
            Console.WriteLine("Du har valt att föra över pengar till ett av " + users[foundReceiverUser].name + "s konton");
            Console.WriteLine("Var god välj vilket konto du vill flytta pengarna till");
            int counter =1;
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
            for (int i = 0; i < users[foundReceiverUser].accounts.Length; i++)
            {
                if (selectedReceiverAccount == i)
                {
                    receiverAccount = i;
                    Console.WriteLine("Du har valt att föra över pengar till " + users[foundReceiverUser].name
                        + "s " + users[foundReceiverUser].accounts[receiverAccount].accountName);
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
        public string accountName { get; set; }
        public decimal accountValue { get; set; }

    }
        /*public string accountName
        {
            get
            {
                return accountName;
            }
            set
            {
                this.accountName = accountName;
            }
        }*/

        /* public decimal accountValue
         {
             get
             {
                 return accountValue;
             }
             set
             {
                 this.accountValue = accountValue;
             }
         }*/
    

    public class User
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string pinCode { get; set; }
        public Account[] accounts { get; set; }

    }
}


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
/*public Account[] accounts
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
}*/






