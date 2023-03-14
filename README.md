# Bank Application

## Inledning

>I kursen Programmering i C# på Chas Academy skulle vi redovisa våra kunskaper i C# genom att bygga en bankapplikation. Detta är min redovisning från denna kurs. Parallellt med kursen på Chas Academy läste jag även av eget fördjupningsintresse online-kursen *Complete C# Masterclass* på Udemy.

## Projektbeskrivning 

> Det här är en bankapplikation som erbjuder flera olika användare möjligheten att logga in med pinkod och användarnamn och sedan från en lista av menyval utföra olika bankärenden så som transaktioner i olika valutor mellan egna konton, transaktioner till annan användare, vanliga uttag och insättningar samt möjligheten att öppna nya konton med bara namn eller namn och summa. Användarna i banken har konton med olika valuta och appen håller reda på vilken valuta som finns på respektive konto, valuta omvandlas sedan vid överföringar mellan konton. 

### Säkerhet

> - Om användaren anger fel pinkod tre gånger i rad stängs inloggnigen av i tre minuter
> - Krav på angivande av pinkod vid uttag och överföringar
> - Oblektorienterad programmering 
> - Felhantering, try-catch

### Programmets struktur

> Programmet består av tre klasser - Program, User och Account och en Mainmetod. I Main byggs först objekten där varje user utifrån objektklassen User tilldelas respektive attribut som namn, användarnamn, pinkod och en array av konton med kontonamn och summa var. I Main finns också kod som hanterar inloggningen. I Program finns merparten av de metoder som används i programmet, så som metoder för exv transaktioner, uttag, insättningar etc, i kronologisk ordning sett till hur de presenteras för användaren i menyn. Med några vanligt förekommande hjälpmetoder placerade i mitten av klassen.  

### Programflöde

> När användaren har lyckats logga in får han/hon möjlighet att ur menyn välja ett bankärende som ska utföras, beroende på val skickas användaren sedan vidare till den/de metoder som hanterar vald funktionalitet och tas efter bankärendets slut vid entertryckning åter till huvudmenyn. Under programmets körning och vid varje bankärende lagras eventuell förändrad data i objekten så att dessa hålls uppdaterade vilket gör att en användare kan logga ut och en annan kan logga in och förändringarna kvarstår. Vilket gör appen mycket dynamisk och simuleringen blir lik en verklig bank. 

### Metodmässig struktur

> Jag har strävat efter att bygga upp en grundstruktur som ska vara lätt att överblicka för den som ser koden för första gången, där varje funktionalitet i programmet består av 1-8 metoder och där varje metod så gott det går getts en uppgift för att så långt som möjligt följa Single responsibility principle. Jag har exempelvis delat upp funktionaliteten för test av pinkod, väljande av överföringsbelopp, test av valuta, och själva överföringen i olika metoder. På det sättet kan inmatningar testas för att undvika krascher, och DRY-principen efterlevas - att undvika upprepningar. 
<br>

#### Mer ingående om metodstruktur och flöde

> Efter det att användare skapats och en giltig användare lyckats logga in kan användaren i Huvudmenyn som består av metoden MainMenu välja mellan valen: Se konton och saldon, Överföringar, Ta ut pengar, Sätta in pengar, Skapa nytt konto samt Överföringar till annan användare. 
> - Om användaren väljer Se konton och saldo kommer metoden ListAccounts att anropas som loopar igenom användarens samtliga konton och visar dessa på skärmen med saldo och valuta, användaren tas sedan åter till Huvudmenyn. 
> - Om användaren väljer Överföringar kommer metoden TransferFunds att anropas som i sin tur först anropar ListAccountsForTransfer vilken loopar igenom användarens samtliga konton och listar dem med kontonamn, valuta och saldo och sedan återvänder till TransferFunds. Efter det anropar TransferFunds metoderna SelectWithdrawalAccount respektive SelectDepositAccount som båda låter användaren välja från- och tillkonto och läser in svaret samt testar det för att se att inputen är giltig och i annat fall skriver ut ett felmeddelande tills rätt typ av input anges, och slutligen tar med sig kontoidn till TransferFunds. Sedan anropar TransferFunds metoden GetTransferAmount som läser in användarens önskade summa, testar inputen och återvänder med denna till TransferFunds. Slutligen anropar TransferFunds metoden MakeTransfer som först testar om från- respektive tillkontot innehåller euro eller inte med hjälp av metoden CheckIfTravelAccount. MakeTransfer testar sedan om det finns tillräckligt med pengar på frånkontot och skriver ut ett felmeddelande om det inte finns. Om tillräckligt finns går metoden vidare och konverterar valuta och sätter outputstring meddelandets currencyvariabel och gör slutligen själva överföringen. Sista av allt skriver MakeTransfer ut ett resultatmeddelande till användaren som visar hur de båda kontona påverkats.
> - Om användaren väljer ta ut eller sätta in pengar är processen liknande den ovan men bara halva vägen och med den skillnaden att det vid uttag även testas för pinkod.
> - Ifall användaren väljer att skapa ett nytt konto anropas från huvudmenyn metoden CreateNewAccount som ber användaren om önskat kontonamn och ger sedan användaren valet att skapa ett konto med eller utan en summa. Beroende på om användaren väljer att skapa ett nytt konto med bara kontonamn eller även med summa dirigeras han/hon vidare till den överlagrade metoden CreateAccount i Userklassen. Denna metod skapar ett nytt konto med antingen kontonamn eller kontonamn och summa genom att förstora användarens kontoarray och lägga in det nyskapade kontot sist i den förstorade arrayen.
> - Om användaren gör valet Överföringar till annan användare i huvudmenyn ser struktur och flöde ut som vid valet Överföringar med skillnaden att användaren ges möjlighet att välja annan mottagare och sedan ett av dennes konton som destinationskonto.



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



