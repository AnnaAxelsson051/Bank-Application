# Bank Application

## Inledning

>I kursen Programmering i C# på Chas Academy skulle vi redovisa våra kunskaper i C# genom att bygga en bank applikation. Detta är min redovisning från denna kurs. Parallellt med kursen på Chas Academy läste jag även av eget fördjupningsintresse online-kursen *Complete C# Masterclass* på Udemy.

### Genom kursen Programmering i C# på Chas Academy har jag fått mycket kunskaper om

#### Collections
> - Dictionaries som erbjuder lagring av data i form av key-value pair 
> - Multidimensionella arrayer och hur man lagrar data i form av ett matrix 
> - Jagged arrays som gör det möjligt att lagra arrayer av olika storlekar inuti andra arrayer
> - Tuples som kan användas när man vill returnera flera värden från en metod
> - Arraylists som blir väldigt användbara när objektstorleken behöver ökas dynamiskt
> - Hashtables som mappar och ger tillgång till värden via nycklar
#### Objektorienterad programmering
>  - Klasser som ger en abstrakt ritning utifrån vilket man kan skapa objekt med vissa egenskaper och sedan  använda objektmetoder på dessa
> - Inkapsling för att kunna dölja data för användaren och göra program säkrare 
> -  Propfull som ger en publik och en privat variabel, getters/setters för att effektivt tillskriva och komma åt värden på objekt
> - Övriga properties, överlagrade metoder och konstruktorer för att skapa objekt 
> - Arv för att kunna härleda egenskaper från en överordnad basklass till objekt av en underklass
> - Polymorphism då man vill att en och samma klass har många implementeringar
#### Generics
> - Hur man kan definiera generiska klasser, fält och metoder genom att använda typ parametern och utan att använda någon specifik datatyp
#### Git
> - Hur man effektivt kan använda bland annat git pull för att i team samarbeta kring ett projekt
#### SqlLite
 > - Hur man kan koppla C# till SqlLite för att komma åt värden i en databas
<br>

## Projektbeskrivning 

>Det här är en bankapplikation som erbjuder flera användare möjligheten att logga in med pinkod och användarnamn och från en lista av menyval utföra olika bankärenden så som transaktioner mellan egna konton, transaktioner till annan användare, vanliga uttag och insättningar samt möjligheten att öppna nya konton med bara namn eller namn och summa. Användarna i banken har konton med olika valuta och appen håller reda på vilken valuta som finns på respektive konto, och valuta omvandlas vid överföringar mellan konton. Efter tre misslyckade försök stängs inloggningningen av i tre minuter.

### Val av metod 

> Uppgiftsbeskrivningen bestod av ett antal krav och ännu fler extrautmaningar, jag valde att göra alla extrautmaningar utom att inledningsvis läsa från fil (eftersom den inte passade så bra med modellen jag valt) vilket var både intressant och lärorikt. Jag valde att använda mig av Objektorienterad programmering eftersom det är en modell som passar bra till appar där man strävar efter en hög säkerhet och det är också ett bra och effektivt sätt att ge objekt, så som i det här fallet användare, olika konton. 
Annan ev lösning som övervägts: Jag funderade först på att bygga appen med hjälp av Jagged arrayer för att lära mig extra om det och för att jobba mer praktiskt med Jagged arrayer, men det landade i OOP på grund av att jag kände att det skulle passa den här typen av app bättre till följd av säkerhetsaspekten och möjligheten att gömma data med privata fält så att andra delar av programmet inte kan komma åt och påverka den.

### Felhantering

> För att undvika att applikationen kraschar vid felaktig inmatning har jag använt try catch block och undantagshantering, samt tester innan överföringar och uttag för att undvika eventuella kvarvarande minusbelopp på uttagskontot. 
Framtida förbättring: Jag hade även säkert kunnat använda try catch på vissa ställen där jag i koden istället testat med if, och det är något jag kan förbättra i en framtida version.

### Struktur

> Jag har strävat efter att bygga upp en grundstruktur som ska vara lätt att överblicka för den som ser koden för första gången, där varje funktionalitet i programmet består av 1-4 metoder där varje metod så gott det går getts en uppgift för att så långt som möjligt följa Single responsibility principle. Jag har exempelvis delat upp funktionaliteten för att leta upp rätt mottagaranvändare för exv en överföring i en metod, och väljandet av överföringsbelopp i en annan. Mycket på grund av att jag extensivt velat testa inmatningar för att undvika krascher och även hålla mig till DRY-principen - och undvika upprepningar.
Kritik: Jag hade kanske kunnat lägga all kod som tillhör en funktionalitet i samma metod, det hade blivit långa metoder med en del upprepningar men kanske vunnit i överblickbarhet. Jag föredrar dock det sätt jag gjorde på grund av att jag personligen tycker det blir mer funktionellt att återanvända mycket kod.
<br>

> Min tanke bakom strukturen: I fall då en viss funktionalitet (Exv överföringar) kräver fler än 1 metod har jag valt att bygga upp det så att den kronologiskt översta metoden (huvudmetoden) i varje funktionsslinga (exv metoden “transaktions”), som också är den som anropas från användarmenyn, i sin tur anropar olika hjälpmetoder under denna för att exv välja ut rätt konto, välja ut rätt överföringsmottagare etc - på det sättet kan man i huvudmetoden snabbt få en överblick över vad som sker i koden och sen vidare undersöka hur de olika anropade hjälpmetoderna är uppbyggda. 
Eventuella förbättringar: Om jag hade haft mer tid skulle jag kanske även försöka samla all kod som tillhör konvertering av valuta i en egen metod istället för att ha det i MakeTransaction, så att det på det viset blir så att säga en sektion med valutakonverteringsmetoder och för att MakeTransaction ska bli kortare.
<br>

>Om jag hade haft mer tid hade jag säkert också kunnat göra ännu fler återanvändningar för att minska kodmängden ännu mer, och det är något jag gillar och vill tänka ytterligare på i en framtida version.
Jag hade också gärna utvecklat applikationen till att bestå av fler filer/klasser, dels av säkerhetsskäl men också för än ökad överblickbarhet.

### Om jag haft mer tid skulle jag också: 
> - Bygga ett flödesschema för appen som ger bra överblick 
> - Implementera en front end del med en välkomnande bank log in sida
> - Kanske funktionalitet för ett varningssljud om anv trycker fel pinkod
> - Fler användare i banken
> - Hantering av ännu fler valutor
> - Möjlighet att lägga till fler användare dvs möjlighet för någon ny att bli medlem i banken
> - Möjlighet att göra överföring till andra konton i andra banker
> - Möjlighet att betala räkningar
> - Möjlighet till autogirobetalningar
> - Ett “help” - alternativ i menyn där användaren kan se svar på de vanligaste frågorna
> - En kontaktsektion där användaren kan kontakta banken 
> - Sparade kontotransaktioner mellan körningar

