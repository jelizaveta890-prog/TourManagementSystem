# Tour Management System - Reisihaldussüsteem

### Projekti kirjeldus
Meie tiimi loodud rakendus on CRUD-tüüpi reisihaldussüsteem, mis mõeldud väiksemale reisibüroole. Projekti eesmärk oli asendada seni kasutatud tüütu Exceli tabelite põhine majandamine korraliku ja turvalise veebirakendusega. Süsteemis saab administraator uusi reise juurde lisada, olemasolevaid pakette vaadata, nende andmeid/hindu muuta ja vanu või aegunud reise nimekirjast kustutada.

### Sihtkasutajad
* Reisibüroo administraatorid
* Kliendihaldurid ja reisikonsultandid

### Kasutatud tehnoloogiad
* **Backend:** C# (.NET Core)
* **Andmebaas ja ORM:** Entity Framework Core (SQL Server, kasutasime Code-First lähenemist)
* **Frontend:** ASP.NET Core Razor Views (HTML5, CSS3)
* **Disain:** Bootstrap 5 (kasutasime valmis kaartide süsteemi, et leht näeks kaasaegne välja)

### Paigaldusjuhend (Kuidas käivitada)
1. Tõmba projekt endale arvutisse (klooni repositoorium `git clone` käsuga või laadi zip-failina alla).
2. Ava fail `TourManagementSystem.sln` programmiga Microsoft Visual Studio.
3. Vaata üle andmebaasi ühendussõne (*Connection String*) failis `appsettings.json`, et see sobiks sinu kohaliku SQL Serveriga (LocalDB).
4. Vajuta Visual Studios rohelist **Run** nuppu või klaviatuuril `F5`.
5. Kuna koodis on kasutusel `context.Database.EnsureCreated()`, siis teeb programm esimesel käivitamisel vajaliku andmebaasi ja tabelid ise valmis.

### Kasutusjuhend
* **Pealeht (Index):** Kui rakendus käivitub, avaneb kohe reiside kataloog (*Tours Catalog*), kus on näha kõik reisid kaartidena koos hindade ja sihtkohtadega.
* **Uue reisi lisamine (Create):** Klikka nupule "+ Add New Tour", täida lahtrid ja salvesta ära.
* **Andmete vaatamine (Details):** Klikka reisi kaardil nuppu "Details" ja näed täpsemat infot selle reisi kohta.
* **Muutmine (Edit):** Vali reisi juurest "Edit", muuda vajalikud väljad ja uuenda andmed.
* **Kustutamine (Delete):** Vali nupp "Delete", süsteem küsib igaks juhuks kinnitust ja pärast seda kustutab reisi andmebaasist ära.

### Tehisintellekti (AI) kasutamine
* **Kasutatud tööriist:** Gemini (Google)
* **Milleks kasutasime:** AI-st oli abi koodi puhastamisel (võtsime failist `Program.cs` välja üleliigsed lokaliseerimise seaded), Razor vaadete vigade otsimisel (näiteks parandasime ära `@item.Id` muutuja vea `Details.cshtml` lehel) ning aitas liidest ingliskeelseks teha. Projekti põhimõtteline loogika ja CRUD-funktsioonid on tehtud ise loengumaterjalide põhjal.

### Kasutatud allikad
* Microsoft Learn: ASP.NET Core MVC õppematerjalid ja dokumentatsioon
* Bootstrap 5: Küljenduse, nuppude ja kaartide (Cards) näidised ja koodid

### Autorid ja rollide jaotus

* **Liliia Melnyk** (Full-stack arendaja)
  * Kirjutas C# backend-loogika ja pani paika andmebaasi poole (Entity Framework Core). Tegeles ka Giti repositooriumi haldamisega ja parandas koodis tekkinud bugisid.

* **Johanna Tima** (Projektijuht / Disainer)
  * Jälgis, et asjad saaksid õigeks ajaks valmis ja tegeles planeerimisega. 

* **Jelizaveta Sukhomlynova** (Testija / Dokumenteerija)
  * Testis programmi funktsioonid läbi (kontrollis, et Details, Edit ja Delete nupud reaalselt töötaksid ilma vigadeta). Pani kokku projekti lõppdokumentatsiooni ja selle sama `README.md` faili.