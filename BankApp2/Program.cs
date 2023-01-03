using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using Internal;
using static BankApp2.Program;

// Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut)...
//och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten

//När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:
//se konton o saldo överföringar mellan konton, ta ut pengar, logga ut

//TODONär en funktion har kört klart ska användaren få upp texten "Tryck enter för att komma till huvudmenyn".
//När användaren tryckt enter kommer menyn upp igen.

//Om användaren väljer "Logga ut" ska programmet inte stänga av. Användaren ska komma till inloggningen igen.
//Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer,
//ska systemet meddela att det är ett "ogiltigt val".

//TODO när anv väljer se konton o saldo Användaren ska få en utskrift av de olika konton som
//användaren har och hur mycket pengar det finns på dessa i kr och ören

// Saldon för alla konton sätts vid starten av programmet (du ställer in en en summa som
//finns på varje konto i koden) så om programmet startas om återställs alla saldon.

//TODO när anv väljer överföringar mellan konton ska hen kunna välja ett konto att ta pengar från,
//ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa, efter summan flyttas
//ska användaren få se vilken summa som finns på dessa två konton som påverkades

//Det måste finnas täckning på konton man vill flytta pengar från för beloppet man vill flytta

//TODO när anv väljer ta ut pengar Användaren ska kunna välja ett av sina konton samt en summa
//Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar

//TODO Pengarna ska sedan tas bort från det konto som valdes Sist av allt ska systemet skriva ut det nya
//saldot på det kontot

namespace BankApp2;
class Program

//helth = username
//defense = pincode
{
    private static string loggedInUser;
    private static object accounts;

    static void Main(string[] args)
    {
        //CREATE ARRAY OF USERS


        /*string[] userNames = new string[]
        {"Arvin", "Billy", "Camilla", "Daniel", "Emily"};
        int[] Pincodes = new int[]
        {1111,2222,3333,4444,5555};

        //User[] users = new User[]
        User[][][] users = new User[][][]
                            {
                                new User[][]
                                {
                                    new User[] { "akonto", "bkonto"},
                                    new User[] { 400, 500}
                                },
                                new User[][]
                                {
                                    new kontoNamn[] { "akonto", "bkonto", "ckonto"},
                                    new konstSaldo[] { 400, 500, 600}
                                }
                                },

                            new User[2][]
                                {
                                    new int[3] { 1, 2, 3},
                                    new int[2] { 4, 5}
                                },
                                new User[2][]
                                {
                                    new int[3] { 1, 2, 3},
                                    new int[2] { 4, 5}
                                },





        User[][] users = new User[4][]{
           new UserName [5]
            {"Arvin", "Billy", "Camilla", "Daniel", "Emily"},
           new AccountName [5]
            {"Lönekonto", "Sparkonto", "Resekonto", "Välgörenhetskonto", "Emily"},
            new Pincode[5]
            {1111,2222,3333,4444,5555},
            new AccountValue[5]
            {200,300,400,500,600},
        };*/




        User[] users = new User[]
        {
        new User
        {
            Name = "A",
            UserName = "Arvin",
            PinCode = 1111,
            Accounts = new Account[]          //user accounts
                {
                    new Account
                    {
                        AccountName = "Lönekonto",
                        AccountValue = 100
                    },
                    new Account
                    {
                        AccountName = "Sparkonto",
                        AccountValue = 200
                    },
                }
        },

            new User
            {
                Name = "B",
                UserName = "Billy",
                PinCode = 2222,
                Accounts = new Account[]
                {
                    new Account
                    {
                        AccountName = "Lönekonto",
                        AccountValue = 100
                    },
                    new Account
                    {
                        AccountName = "Sparkonto",
                        AccountValue = 200
                    },
                    new Account
                    {
                        AccountName = "Resekonto",
                        AccountValue= 300
                    },

                }
            },
            new User
            {
                Name = "C",
                UserName = "Camilla",
                PinCode = 3333,
                Accounts = new Account[]
                {
                    new Account
                    {
                        AccountName = "Lönekonto",
                        AccountValue = 100
                    },
                    new Account
                    {
                        AccountName = "Sparkonto",
                        AccountValue = 200
                    },
                    new Account
                    {
                        AccountName = "Resekonto",
                        AccountValue= 300
                    },
                     new Account
                    {
                        AccountName = "Välgörenhetskonto",
                        AccountValue= 400
                    },

                }
            },

            new User
            {
                Name = "D",
                UserName = "Daniel",
                PinCode = 4444,
                Accounts = new Account[]
                {
                    new Account
                    {
                        AccountName = "Lönekonto",
                        AccountValue = 100
                    },
                    new Account
                    {
                        AccountName = "Sparkonto",
                        AccountValue = 200
                    },
                    new Account
                    {
                        AccountName = "Resekonto",
                        AccountValue= 300
                    },
                    new Account
                    {
                        AccountName = "Välgörenhetskonto",
                        AccountValue= 400
                    },
                    new Account
                    {
                        AccountName = "Renoveringskonto",
                        AccountValue= 500
                    },

                }
            },

            new User
            {
                Name = "E",
                UserName = "Emily",
                PinCode = 5555,
                Accounts = new Account[]
                {
                    new Account
                    {
                        AccountName = "Lönekonto",
                        AccountValue = 100
                    },
                    new Account
                    {
                        AccountName = "Sparkonto",
                        AccountValue = 200
                    },
                    new Account
                    {
                        AccountName = "Resekonto",
                        AccountValue= 300
                    },
                    new Account
                    {
                        AccountName = "Välgörenhetskonto",
                        AccountValue= 400
                    },
                    new Account
                    {
                        AccountName = "Renoveringskonto",
                        AccountValue= 500
                    },
                    new Account
                    {
                        AccountName = "Reparationskonto",
                        AccountValue= 600
                    },

                }
            }
        };

        logInMenu();

        //LOG IN
        void logInMenu()
        {
            Console.WriteLine("Log in");
            bool logInMenu = true;
            do
            {
                Console.WriteLine("Please enter your username");
                string? userName = Console.ReadLine();
                Console.WriteLine("Please enter your pinconde");
                string? input = Console.ReadLine();
                int userPinCode = Int32.Parse(input);


                //LOOP USER ARRAY CHECK IF USERNAME AND PINCODE MATCH
                //User[] users = new User[]..


                foreach (object user in users.GetType().GetProperties())
                {
                    if ((userName.Equals(user.UserName)) && (userPinCode == user.PinCode))
                    {
                        loggedInUser = user;
                    }

                }

           

                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i].Name.Equals("A") && (users[i].UserName.Equals("Arvin") && (users[i].PinCode.Equals("1111"))))
                    {
                        Console.WriteLine("Welcome Arvin you have successfully logged in");
                        loggedInUser = users[0];
                        logInMenu = false;
                    }
                    else if (users[i].Name.Equals("B") && (users[i].UserName.Equals("Billy") && (users[i].PinCode.Equals("2222"))))
                    {
                        Console.WriteLine("Welcome Arvin you have successfully logged in");
                        loggedInUser = "B";
                        logInMenu = false;
                    }
                    else if (users[i].Name.Equals("C") && (users[i].UserName.Equals("Camilla") && (users[i].PinCode.Equals("3333"))))
                    {
                        Console.WriteLine("Welcome Arvin you have successfully logged in");
                        loggedInUser = "C";
                        logInMenu = false;
                    }
                    else if (users[i].Name.Equals("D") && (users[i].UserName.Equals("Daniel") && (users[i].PinCode.Equals("4444"))))
                    {
                        Console.WriteLine("Welcome Arvin you have successfully logged in");
                        loggedInUser = "D";
                        logInMenu = false;
                    }
                    else if (users[i].Name.Equals("E") && (users[i].UserName.Equals("Emily") && (users[i].PinCode.Equals("5555"))))
                    {
                        Console.WriteLine("Welcome Arvin you have successfully logged in");
                        loggedInUser = "E";
                        logInMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you were unable to log in, you must have entered the wrong username or pincode, " +
                            "please try again");
                    }
                }

            } while (logInMenu);
            mainMenu();
        }


        //MAIN MENU
        void mainMenu()
        {
            Console.WriteLine("Menu system");
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("Please select one of the following");
                Console.WriteLine("1 Se konton och saldon");
                Console.WriteLine("2 Överföringar");
                Console.WriteLine("3 Ta ut pengar");
                Console.WriteLine("E Exit");
                string? choice = Console.ReadLine().ToUpper();
                switch (choice)
                {

                    //LIST ACCOUNTS?
                    //Accounts = new Account[]
                 
                    case "1":
                        listAccounts();
                        break;

                    //CREATE NEW ACCOUNT / USER?
                    case "2":
                        Console.WriteLine("Creating a new monster");
                        users = addUser(users, parseRow("Tobbe, 20,1+,12"));
                        Console.WriteLine("User successfully added to database");
                        break;
                    case "3":
                        Console.WriteLine("Update selected");
                        User updateUser = users[1];
                        Account updateAccount = users[1].Accounts[0];
                        updateUser.Name = "johan";
                        updateAccount.AccountValue = 15;
                        break;
                    case "E":
                        Console.WriteLine("E selected");
                        mainMenu = false;
                        logInMenu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Please type either 1 oe E and press enter");
                        break;

                }
            }
        }

        void listAccounts()
        {
            //helth = username
            //defense = pincode
            Console.WriteLine("Listing all accounts");
            for (int i = 0; i < accounts.Length; i++)
            {
                Console.WriteLine("name: " + loggedInUser.accounts[i].Name + "salary account: " +
                    accounts[i].salaryAccount + "savings account " + accounts[i].savingsAccount);
                //users?
                Attack[] monsterAttacks = monsters[i].Attacks;
                for (int j = 0; j < monsterAttacks.Length; j++)
                {
                    Console.WriteLine("Index: " + j + 1 + "monster: " + monsterAttacks[j].Name + " attackvalue: " + monsterAttacks[j].AttackValue);
                    //kontonamnen?
                }
            }
            Console.WriteLine();
            mainMenu();

            /*for (int row = 0; row < accounts.Length; row++)
            {
                for (int column = 0; column < accounts[row].Length; column++)
                {
                    display += intArray[row][column].ToString() + " ";
                }
                display += "\n";
            }
            break;*/
        }

        //TRANSFER FUNDS BETWEEN ACCOUNTS
        void transferFunds()
        {
            //lista personens konton
            foreach (Account in loggedInUser.accounts)
            {
                Console.WriteLine(Account.accountValue);
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
                        m.Name = cols[k];          //sätter 0 värdet (tobbe) till name
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
            return m;     //returnerar det nya monster objektet
        }




        //updatedUser = Users[0];
        //Om vi relaterar det till banken kan users [0] va ett antal users som vi stegar igenom
        //Ungefär som login labben att man scannar alla users och kollar om anv fyllt i rätt
        //anvnamn och pinkod för en viss user då ör det luoggedin / current user då brukar man
        //lägga den i en egen variabel eller det är ett sätt iaf (ganska tidigt i 15/12).....

     



    public class Account
    {
    public Account[] AccountName
    {
        get
        {
            return AccountName;
        }
        set
        {
            AccountName = value;
        }
    }

    public Account[] AccountValue
    {
        get
        {
            return AccountValue;
        }
        set
        {
            AccountValue = value;
        }
    }
}

    public class User {

    public Account[] Accounts[];

   
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
       public string UserName
       {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }
        }
        public int PinCode
        {
            get
            {
                return PinCode;
            }
            set
            {
                PinCode = value;
            }
        }
}


