# Bank Application

## Inledning

>I kursen Programmering i C# på Chas Academy skulle vi redovisa våra kunskaper i C# genom att bygga en bankapplikation. Detta är min redovisning från denna kurs. Parallellt med kursen på Chas Academy läste jag även av eget fördjupningsintresse online-kursen *Complete C# Masterclass* på Udemy.

## Projektbeskrivning 

> Det här är en bankapplikation som erbjuder flera användare möjligheten att logga in med pinkod och användarnamn och sedan från en lista av menyval utföra olika bankärenden så som transaktioner mellan egna konton, transaktioner till annan användare, vanliga uttag och insättningar samt möjligheten att öppna nya konton med bara namn eller namn och summa. Användarna i banken har konton med olika valuta och appen håller reda på vilken valuta som finns på respektive konto, valuta omvandlas sedan vid överföringar mellan konton. 

### Säkerhet

> - Om användaren anger fel pinkod tre gånger i rad stängs inloggnigen av i tre minuter
> - Krav på angivande av pinkod vid uttag och överföringar

### Val av metod 

> Jag valde att använda mig av Objektorienterad programmering i detta projekt eftersom OOP är en modell som passar bra till appar där man strävar efter en hög säkerhet och det är också ett bra och effektivt sätt att förse objekt, som i det här fallet användare, med olika konton. 
Annan ev lösning som övervägts: Jag funderade först på att bygga appen med (enbart) jagged arrays och inte OOP för att lära mig extra om det och för att jobba mer praktiskt med jagged arrays, men det landade i OOP på grund av att jag kände att det skulle passa den här typen av app bättre till följd av säkerhetsaspekten och möjligheten att gömma data med privata fält så att andra delar av programmet inte kan komma åt och påverka den.

### Programmets struktur

> Programmet består av tre klasser - Program, User och Account och en Mainmetod. I Main byggs först objekten där varje user utifrån objektklassen User tilldelas respektive attribut som namn, användarnamn, pinkod och en array av konton med kontonamn och summa var. I Main finns också kod som hanterar inloggningen. I Program finns merparten av de metoder som används i programmet, så som metoder för exv transaktioner, uttag, insättningar etc, i kronologisk ordning sett till hur de presenteras för användaren i menyn. Med några vanligt förekommande hjälpmetoder placerade i mitten av klassen. Userklassen innehåller förutom publika och privata fält, getters och setters också två metoder för skapande av konto. På det här sättet har jag velat skydda fält och filer så mycket det går och också åstadkomma en bra överblickbarhet. Jag hade dock kanske velat dela upp programmet i ännu fler filer ur säkerhetssynvinkel men också för att vinna ännu mer i överblickbarnet. 

### Felhantering

> För att undvika att applikationen kraschar vid felaktig inmatning har jag extensivt använt try catch block, undantagshantering och if-satser, samt tester innan överföringar och uttag för att undvika eventuella kvarvarande minusbelopp på uttagskontot.
Framtida förbättring: Jag hade även säkert kunnat använda try catch och exception på vissa ställen där jag i koden istället testat med if, och det är något jag kan förbättra i en framtida version.
Jag har varit noga att ta höjd för användares eventuella varierande användning av versaler vid olika val som involverar bokstäver genom att använda mig av toUpper respektive ignorecase.

### Programflöde

> När användaren har lyckats logga in får han/hon möjlighet att ur menyn välja ett bankärende som ska utföras, beroende på val skickas användaren sedan vidare till den/de metoder som hanterar vald funktionalitet och tas efter bankärendets slut vid entertryckning åter till huvudmenyn. Under programmets körning och vid varje bankärende lagras eventuell förändrad data i objekten så att dessa hålls uppdaterade vilket gör att en användare kan logga ut och en annan kan logga in och förändringarna kvarstår. Vilket gör appen mycket dynamisk och simuleringen blir lik en verklig bank. En fördel hade här varit att läsa in objekten direkt från en databas för att sedan spara in ändringarna i databasen och kunna ha dem kvar efter det att programmet startas om. Det är något jag vill implementera i en framtida version med SQL.

### Metodmässig struktur

> Jag har strävat efter att bygga upp en grundstruktur som ska vara lätt att överblicka för den som ser koden för första gången, där varje funktionalitet i programmet består av 1-8 metoder och där varje metod så gott det går getts en uppgift för att så långt som möjligt följa Single responsibility principle. Jag har exempelvis delat upp funktionaliteten för test av pinkod, väljande av överföringsbelopp, test av valuta, och själva överföringen i olika metoder etc. Mycket på grund av att jag extensivt velat testa inmatningar för att undvika krascher, hålla mig till DRY-principen - och undvika upprepningar.
Kritik: Jag hade kanske kunnat lägga all kod som tillhör en funktionalitet i samma metod, det hade blivit långa metoder med en del upprepningar men kanske vunnit i överblickbarhet. Jag föredrar dock det sätt jag gjorde på grund av att jag personligen tycker det blir mer funktionellt att återanvända mycket kod och med kortare metoder. Vissa metoder hade jag kunnat återanvända mer för att ta bort andra, men då gått miste om situationsanpassade felutskrifter - och istället behövt använda mer generella sådana.   
<br>

> Min tanke bakom strukturen: I fall då en viss funktionalitet (Exv överföringar) kräver fler än 1 metod har jag valt att bygga upp det så att den kronologiskt översta metoden (huvudmetoden) i varje funktionsslinga (exv metoden “TransferFunds”), som också är den som anropas från användarmenyn, i sin tur anropar olika hjälpmetoder (ofta liggandes) under denna för att exv välja välja ut rätt överföringsmottagare, göra överföringen etc - på det sättet kan man i huvudmetoden snabbt få en överblick över vad som sker i koden och sen vidare undersöka hur de olika anropade hjälpmetoderna är uppbyggda. 
Eventuella förbättringar: Om jag hade haft mer tid skulle jag kanske även försöka samla all kod som tillhör konvertering av valuta i en egen metod, istället för att ha det också i MakeTransferOfFundsToDifferentUser, så att den metoden blev kortare.
<br>

>Om jag hade haft mer tid hade jag säkert också kunnat göra ännu fler återanvändningar för att minska kodmängden ännu mer, och det är något jag vill tänka ytterligare på i en framtida version.

#### Mer ingående om metodstruktur och flöde

> Efter det att användare skapats och en giltig användare lyckats logga in kan användaren i Huvudmenyn som består av metoden MainMenu välja mellan valen: Se konton och saldon, Överföringar, Ta ut pengar, Sätta in pengar, Skapa nytt konto samt Överföringar till annan användare. 
> - Om användaren väljer Se konton och saldo kommer metoden ListAccounts att anropas som loopar igenom användarens samtliga konton och visar dessa på skärmen med saldo och valuta, användaren tas sedan åter till Huvudmenyn. 
> - Om användaren väljer Överföringar kommer metoden TransferFunds att anropas som i sin tur först anropar ListAccountsForTransfer vilken loopar igenom användarens samtliga konton och listar dem med kontonamn, valuta och saldo och sedan återvänder till TransferFunds. Efter det anropar TransferFunds metoderna SelectWithdrawalAccount respektive SelectDepositAccount som båda låter användaren välja från- och tillkonto och läser in svaret samt testar det för att se att inputen är giltig och i annat fall skriver ut ett felmeddelande tills rätt typ av input anges, och slutligen tar med sig kontoidn till TransferFunds. Sedan anropar TransferFunds metoden GetTransferAmount som läser in användarens önskade summa, testar inputen och återvänder med denna till TransferFunds. Slutligen anropar TransferFunds metoden MakeTransfer som först testar om från- respektive tillkontot innehåller euro eller inte med hjälp av metoden CheckIfTravelAccount. MakeTransfer testar sedan om det finns tillräckligt med pengar på frånkontot och skriver ut ett felmeddelande om det inte finns. Om tillräckligt finns går metoden vidare och konverterar valuta och sätter outputstring meddelandets currencyvariabel och gör slutligen själva överföringen. Sista av allt skriver MakeTransfer ut ett resultatmeddelande till användaren som visar hur de båda kontona påverkats.
> - Om användaren väljer ta ut eller sätta in pengar är processen liknande den ovan men bara halva vägen och med den skillnaden att det vid uttag även testas för pinkod.
> - Ifall användaren väljer att skapa ett nytt konto anropas från huvudmenyn metoden CreateNewAccount som ber användaren om önskat kontonamn och ger sedan användaren valet att skapa ett konto med eller utan en summa. Beroende på om användaren väljer att skapa ett nytt konto med bara kontonamn eller även med summa dirigeras han/hon vidare till den överlagrade metoden CreateAccount i Userklassen. Denna metod skapar ett nytt konto med antingen kontonamn eller kontonamn och summa genom att förstora användarens kontoarray och lägga in det nyskapade kontot sist i den förstorade arrayen.
> - Om användaren gör valet Överföringar till annan användare i huvudmenyn ser struktur och flöde ut som vid valet Överföringar med skillnaden att användaren ges möjlighet att välja annan mottagare och sedan ett av dennes konton som destinationskonto.

> Jag hade gärna återanvänt metoden ListAccounts eftersom den ser precis likadan ut som ListAccountsForTransfer med undantag att den första returnerar till huvudmenyn, och det är något jag fixat till om jag haft mer tid.

### Version control

> Jag har använt Git för version control och uppdaterat löpande under arbetets gång. En sak jag vill förbättra framöver när det gäller just det är att då jag skriver längre commitmeddelanden dela upp dem i rubrik och undertext/punktlista.

### Om jag haft mer tid skulle jag vilja lägga till följande funktionalitet till projektet: 
> - Koppla till databas och läsa in användare / saldon som sparas mellan körningar
> - Bygga ett flödesschema för appen som ger bra överblick 
> - Implementera en front end del med en välkomnande bank log in sida
> - Maskerad pinkod vid inmatning
> - Endast visa 2 decimaler vid utskrift
> - Ha en paus-i-tre-minuter-vid-fel-pinkod endast för den användare som skrev fel
> - Kanske funktionalitet för ett varningssljud om anv trycker fel pinkod
> - Göra så att användarens egent konto inte listas när han/hon ska välja annan användare att överföra till
> - Fler användare i banken
> - Hantering av ännu fler valutor
> - Möjlighet att lägga till fler användare dvs möjlighet för någon ny att bli medlem i banken
> - Möjlighet att göra överföring till andra konton i andra banker
> - Möjlighet att betala räkningar
> - Möjlighet till autogirobetalningar
> - Ett “help” - alternativ i menyn där användaren kan se svar på de vanligaste frågorna
> - En kontaktsektion där användaren kan kontakta banken 

<br>

### Genom kursen Programmering i C# på Chas Academy och vid byggande och research kring detta projekt har jag fått fördjupade kunskaper om:

#### Collections
> - Dictionaries som erbjuder lagring av data i form av key-value pair
> - Multidimensionella arrayer och hur man lagrar data i form av matrix
> - Jagged arrays som gör det möjligt att lagra arrayer av olika storlekar inuti andra arrayer
> - Tuples som kan användas när man vill returnera flera värden från en metod
> - Arraylists som blir väldigt användbara när objektstorleken behöver ökas dynamiskt
> - Hashtables som mappar och ger tillgång till värden via nycklar
#### Objektorienterad programmering
> - Propfull som ger en publik och en privat variabel, getters/setters för att effektivt tillskriva och komma åt värden på objekt
> - Inkapsling för att kunna dölja data för användaren och göra program säkrare
> - Övriga properties, överlagrade metoder och konstruktorer för att skapa objekt
> - Arv för att kunna härleda egenskaper från en överordnad basklass till objekt av en underklass
> - Polymorphism då man önskar ha en klass med många olika implementeringar
> - Klasser som ger en abstrakt ritning utifrån vilket man kan skapa objekt med vissa egenskaper och sedan använda objektmetoder på dessa
#### Generics
> - Hur man kan definiera generiska klasser, fält och metoder genom att använda typ parametern och utan att använda någon specifik datatyp
#### Git
> - Hur man effektivt kan använda bland annat git pull för att i team samarbeta kring ett projekt
#### SqlLite
 > - Översiktligt - Hur man kan koppla C# till SqlLite för att komma åt värden i en databas

