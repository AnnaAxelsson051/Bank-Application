using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Internal;

//TODO Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut)...
//och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten
//TODO När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:
//se konton o saldo överföringar mellan konton, ta ut pengar, logga ut
//TODONär en funktion har kört klart ska användaren få upp texten "Tryck enter för att komma till huvudmenyn".
//När användaren tryckt enter kommer menyn upp igen.
//TODO Om användaren väljer "Logga ut" ska programmet inte stänga av. Användaren ska komma till inloggningen igen.
//TODO Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer,
//ska systemet meddela att det är ett "ogiltigt val".
//TODO när anv väljer se konton o saldo Användaren ska få en utskrift av de olika konton som
//användaren har och hur mycket pengar det finns på dessa i kr och ören
//TODO Saldon för alla konton sätts vid starten av programmet (du ställer in en en summa som
//finns på varje konto i koden) så om programmet startas om återställs alla saldon.
//TODO när anv väljer överföringar mellan konton ska hen kunna välja ett konto att ta pengar från,
//ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa, efter summan flyttas
//ska användaren få se vilken summa som finns på dessa två konton som påverkades
//TODO Det måste finnas täckning på konton man vill flytta pengar från för beloppet man vill flytta
//TODO när anv väljer ta ut pengar Användaren ska kunna välja ett av sina konton samt en summa
//Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar
//TODO Pengarna ska sedan tas bort från det konto som valdes Sist av allt ska systemet skriva ut det nya
//saldot på det kontot

namespace BankApp2;
class Program

//helth = username
//defense = pincode
{
    static void Main(string[] args)
    {
        //CREATE ARRAY OF USERS
        User[] users = new User[]
        
        {
           //FILL ARRAY med _5_ ANVÄNDARE MED FÖRPROGRAMMERADE NAMN, ANVNAMN, PINKOD
           //OCH EN INNER ARRAY AV KONTON VAR                                  
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
                        AccountValue = 300
                    },
                    new Account
                    {
                        AccountName = "Sparkonto",
                        AccountValue = 400
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
                        AccountName = "Mimic",
                        AccountValue = 40
                    },
                    new Account
                    {
                        AccountName = "Mime",
                        AccountValue = 20
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
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
                        AccountName = "Mimic",
                        AccountValue = 40
                    },
                    new Account
                    {
                        AccountName = "Mime",
                        AccountValue = 20
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },
                     new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
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
                        AccountName = "Mimic",
                        AccountValue = 40
                    },
                    new Account
                    {
                        AccountName = "Mime",
                        AccountValue = 20
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },

                }
            },new User
            {
                Name = "E",
                UserName = "Emily",
                PinCode = 5555,
                Accounts = new Account[]
                {
                    new Account
                    {
                        AccountName = "Mimic",
                        AccountValue = 40
                    },
                    new Account
                    {
                        AccountName = "Mime",
                        AccountValue = 20
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },
                    new Account
                    {
                        AccountName = "Run away",
                        AccountValue= 0
                    },

                }
            }
        };

        

        //LOG IN
        Console.WriteLine("Log in");
        Console.WriteLine("Please enter your username");
        string? userName = Console.ReadLine();
        Console.WriteLine("Please enter your pinconde");
        string? input = Console.ReadLine();
        int userPincode = Int32.Parse(input);

        //MAIN MENU
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
                case "1":
                    Console.WriteLine("Listing all accounts");



                    /*for (int i =0; i<monsters.Length; i++)
                    {
                        Console.WriteLine("name: " + monsters[i].Name + "health: " + monsters[i].Health + "defense " + monsters[i].Defense);
                        //users?
                        Attack[]monsterAttacks = monsters[i].Attacks;
                        for(int j = 0; j<monsterAttacks.Length; j++)
                        {
                            Console.WriteLine("Index: " + j+1 + "monster: " + monsterAttacks[j].Name + " attackvalue: " + monsterAttacks[j].AttackValue);
                            //kontonamnen?
                        }
                    }
                    Console.WriteLine();*/
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
                    break;
                default:
                    Console.WriteLine("Please type either 1 oe E and press enter");
                    break;

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
            }
        }
    }
    public class Account
    {
        private string accountname;    //va name innan 
        private int accountvalue;

        public string AccountName
        {
            get
            {
                return accountname;
            }
            set
            {
                accountname = value;
            }
        }
        public int AccountValue
        {
            get
            {
                return accountvalue;
            }
            set
            {
                accountvalue = value;
            }
        }
    }
    public class User
    {
        private string name;
        private int userName;
        private int pinCode;
        private Account[] accounts;

        public Account[] Accounts
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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Health
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public int Defense
        {
            get
            {
                return pinCode;
            }
            set
            {
                pinCode = value;
            }
        }
    }
}

