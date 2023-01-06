using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;
using Internal;
using static BankApp2.Program;

// Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut)...
//och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten..

//När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:
//se konton o saldo överföringar mellan konton, ta ut pengar, logga ut

//TODONär en funktion har kört klart ska användaren få upp texten "Tryck enter för att komma till huvudmenyn".
//När användaren tryckt enter kommer menyn upp igen.

//Om användaren väljer "Logga ut" ska programmet inte stänga av. Användaren ska komma till inloggningen igen.
//Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer,
//ska systemet meddela att det är ett "ogiltigt val".

//när anv väljer se konton o saldo Användaren ska få en utskrift av de olika konton som
//användaren har och hur mycket pengar det finns på dessa i kr och ören

// Saldon för alla konton sätts vid starten av programmet (du ställer in en en summa som
//finns på varje konto i koden) så om programmet startas om återställs alla saldon.

//TODO när anv väljer överföringar mellan konton ska hen kunna välja ett konto att ta pengar från,
//ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa, efter summan flyttas
//ska användaren få se vilken summa som finns på dessa två konton som påverkades.

//Det måste finnas täckning på konton man vill flytta pengar från för beloppet man vill flytta

//TODO när anv väljer ta ut pengar Användaren ska kunna välja ett av sina konton samt en summa
//Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar

//TODO Pengarna ska sedan tas bort från det konto som valdes Sist av allt ska systemet skriva ut det nya
//saldot på det kontot.

namespace BankApp2;
class Program
{
    private static string loggedInUser;
    private static object accounts;

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
                    if ((user.userName.Equals(userPinCode)) && (user.pinCode.Equals(userPinCode)))
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
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Var god välj något av följande alternativ");
                Console.WriteLine("1 Se konton och saldon");
                Console.WriteLine("2 Överföringar");
                Console.WriteLine("3 Ta ut pengar");
                Console.WriteLine("E Exit");
                string? choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "1":
                        listAccounts(user);
                        break;
                    case "2":
                        transaction(user);
                        break;
                    case "3":
                        withdrawal(user);

                        break;
                    case "E":
                        Console.WriteLine("E har valts, du loggas nu ut");
                        mainMenu = false;
                        logInMenu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Var god ange antingen val 1-3 eller E och tryck enter");
                        break;

                }
            }
        }


        void listAccounts(User user)
        {
            Console.WriteLine("Nedan listas alla dina konton");

            for (int i = 0; i < user.accounts.Length; i++)
            {
                Console.Write(++i + ". " + user.accounts[i].accountNames + "\t");
                //increase with 1 to display tex 1 - 3
            }
            for (int i = 0; i < user.accounts.Length; i++)
            {
                Console.Write(user.accounts[i].accountValues + "\t");
            }
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }



        void transaction(User user)
        {
            listAccounts(user);
            int foundWithdrawalAccount = selectWithdrawalAccount(user);
            int foundDepositAccount = selectDepositAccount(user);

            Console.WriteLine("Var god ange den summa du önskar överföra");
            string? input = Console.ReadLine();
            decimal transferAmount = Int32.Parse(input);

            makeTransfer(foundWithdrawalAccount, foundDepositAccount, transferAmount, user);

        }

        void makeTransfer(int foundWithdrawalAccount, int foundDepositAccount, decimal transferAmount, User user)
        {
            bool notSufficientFunds = true;
            do
            {
                try
                {
                    decimal withdrawalAccountPostTransfer =
                    user.accounts[foundWithdrawalAccount].accountValues - transferAmount;
                    notSufficientFunds = false;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Tyvärr finns inte tillräckligt med pengar på kontot eller så har du angett en ogiltig inmatning, ange ett nytt belopp");
                }
            } while (notSufficientFunds);

            decimal depositAccountPostTransfer =
            user.accounts[foundWithdrawalAccount].accountValues + transferAmount;

            Console.WriteLine("Du har nu överfört " + transferAmount + " kr från ditt " +
            user.accounts[foundWithdrawalAccount].accountNames + ". Kvar på det kontot finns nu " +
            user.accounts[foundWithdrawalAccount].accountValues + " kr. Och på ditt " +
            user.accounts[foundDepositAccount].accountNames + " finns nu " +
            depositAccountPostTransfer + " kr.");
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();
        }


        int selectWithdrawalAccount(User user)
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
            foundWithdrawalAccount = findWithdrawalAccount(withdrawalAccount, user);
            return foundWithdrawalAccount;
        }

        int selectDepositAccount(User user)
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
                    //Console.WriteLine("Du har angett val " + choice);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Oj, du måste ha angivit ett oriktigt val. Var vänlig försök igen. " +
                        "Välj det konto du vill flytta pengarna till");
                }
            } while (inCorrectInput2);
            depositAccount = -1;
            foundDepositAccount = findDepositAccount(depositAccount, user);
            return foundDepositAccount;
        }


        int findWithdrawalAccount(int withdrawalAccount, User user)
        {
            int selectedWithDrawalAccount = 0;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (withdrawalAccount == i)
                {
                    Console.WriteLine("Du har angett kontot " + user.accounts[i].accountNames);
                    selectedWithDrawalAccount = i;
                }
            }
            return selectedWithDrawalAccount;
        }

        int findDepositAccount(int depositAccount, User user)
        {
            int selectedDepositAccount = 0;
            for (int i = 0; i < user.accounts.Length; i++)
            {
                if (depositAccount == i)
                {
                    Console.WriteLine("Du har angett kontot " + user.accounts[i].accountNames);
                    selectedDepositAccount = i;
                }
            }
            return selectedDepositAccount;
        }


        void withdrawal(User user)
        {
            listAccounts(user);
            int foundWithdrawalAccount = selectWithdrawalAccount(user);

            Console.WriteLine("Var god ange den summa du önskar ta ut");
            string? input = Console.ReadLine();
            decimal withdrawalAmount = Int32.Parse(input);

            makeWithdrawal(foundWithdrawalAccount, withdrawalAmount, user);
        }

        void makeWithdrawal(int foundWithdrawalAccount, decimal withdrawalAmount, User user)
        {
            bool notSufficientFunds = true;
            do
            {
                try
                {
                    decimal withdrawalAccountPostTransfer =
                    user.accounts[foundWithdrawalAccount].accountValues - withdrawalAmount;
                    notSufficientFunds = false;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Tyvärr finns inte tillräckligt med pengar på kontot eller så har du angett en ogiltig inmatning, ange ett nytt belopp");
                }
            } while (notSufficientFunds);

            decimal depositAccountPostTransfer =
            user.accounts[foundWithdrawalAccount].accountValues + withdrawalAmount;

            Console.WriteLine("Du har nu överfört " + withdrawalAmount + " kr från ditt " +
            user.accounts[foundWithdrawalAccount].accountNames + ". Kvar på det kontot finns nu " +
            user.accounts[foundWithdrawalAccount].accountValues);
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma till huvudmenyn");
            Console.ReadLine();

        }
    }



    /*//TRANSFER FUNDS BETWEEN ACCOUNTS
    void transferFunds()
    {
        //lista personens konton
        foreach (Account in loggedInUser.accounts)
        {
            Console.WriteLine(Account.accountValues);
        }
        //fråga från vilket konto
        Console.WriteLine("Please enter what account you would like to transfer the sumb from: ");
        string? input1 = Console.ReadLine();
        int withdrawalAccount = Int32.Parse(input);
        if (withdrawalAccount.amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        //fråga om summa
        Console.WriteLine("Please enter the amount you would like to transfer: ");
        string? input = Console.ReadLine();
        int transferAmount = Int32.Parse(input);
        if (transferAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(transferAmount), "amount of withdrawan must be positive");
        }
        //fråga till vilket konto
        Console.WriteLine("Please enter what account you would like to transfer the sumb to: ");
        string? input2 = Console.ReadLine();
        int destinationAccount = Int32.Parse(input);



        int newSumbOnDestinationAccount = destinationAccount + withdrawalAccount;
        Console.WriteLine("You have successfylly transferred " + transferAmount);
        Console.WriteLine(+" now contains " + );
        Console.WriteLine(+" now contains " + );

        Console.WriteLine("Tryck enter för att komma till huvudmenyn");
        //if (e.Key == Key.Return)
        if (e.KeyValue == 13)
        {
            mainMenu();
        }
    }

    //SKAPAR PLATS FÖR ETT NYTT KONTO I ARRAYEN AV KONTON OCH LÄGGER TILL ETT KONTO??
    //metod addMonster som får en array av monster (oldMonsters) och ett nytt att lägga till (monsterToadd)
    //returnerar en ny array av monster med ett extra tillagt

    User[] addUser(User[] oldUsers, User userToAdd)
    {
        int a = users.Length;
        int numberOfUsers = oldUsers.Length;                            //spara längden av gamla kontoarrayen oldMonsters  
        User[] newUsers = new User[numberOfUsers + 1];    //skapa ny array newMonsters med en til plats
        for (int l = 0; l < numberOfUsers; l++)
        {
            newUsers[l] = oldUsers[l];                          //kopiera värdena till den nya
        }
        newUsers[numberOfUsers] = userToAdd;                 //lägger till ett nytt monster
        return newUsers;
    }
    */




        /*
        //CREATE NEW ACCOUNT MONSTER?
        // monsters = addMonster(monsters, parseRow("Tobbe, 20,1+,12"));
        //Console.WriteLine("Monster successfully added to database");

        User parseRow(string monsterRow)       //får in tex stringen "Tobbe, 20,1+,12"
        {
            var cols = monsterRow.Split(',');      //splittar den 
            User m = new User();             //skapar ett nytt monsterobjekt

            for (int k = 0; k < cols.Length; k++)             //lopar igenom antal vrden man skickade
            {
                Console.WriteLine("Inner for each loop" + k + "col" + cols[k]);       //skriver ut varje index k och dess värde
                switch (k)
                {
                    case 0:
                        m.name = cols[k];          //sätter 0 värdet (tobbe) till name
                        break;
                    case 1:
                        m.Health = int.Parse(cols[k]);      //sätter andra värdet (20) till health
                        break;
                    case 2:
                        break;
                    case 3:
                        m.Defense = int.Parse(cols[k]);       //sätter sista värdet till defense
                        break;


                }

            }
            return m;     //returnerar det nya monster objektet*/
    }




    //updatedUser = Users[0];
    //Om vi relaterar det till banken kan users [0] va ett antal users som vi stegar igenom
    //Ungefär som login labben att man scannar alla users och kollar om anv fyllt i rätt
    //anvnamn och pinkod för en viss user då ör det luoggedin / current user då brukar man
    //lägga den i en egen variabel eller det är ett sätt iaf (ganska tidigt i 15/12).....





    public class Account
    {

        public Account(string accountNames, decimal accountValues)
        {
            this.accountNames = accountNames;
            this.accountValues = accountValues;

        }
        public string accountNames
        {
            get
            {
                return accountNames;
            }
            set
            {
                this.accountNames = accountNames;
            }
        }

        public decimal accountValues
        {
            get
            {
                return accountValues;
            }
            set
            {
                this.accountValues = accountValues;
            }
        }
    }

    public class User {

        //{ get; set; }
        //private byte[][] array;

       /* public User(string name, string userName, string pinCode, Account[] accounts)
        {
            this.name = name;
            this.userName = userName;
            this.pinCode = pinCode;
            this.accounts = accounts;
        }*/

        public string name
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
        }
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


