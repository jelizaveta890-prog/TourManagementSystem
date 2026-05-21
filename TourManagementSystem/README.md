# Tour Management System

### Projekti kirjeldus
Antud rakendus on CRUD-tüüpi reisihaldussüsteem, mis on loodud reisibüroole. Süsteem loodi selleks, et asendada senine ebaefektiivne tabelipõhine reiside haldus digitaalse ja turvalise veebirakendusega. Süsteem võimaldab administraatoritel reise lisada, olemasolevaid reise vaadata, nende andmeid muuta ning vajadusel reise nimekirjast kustutada.

### Sihtkasutajad
* Reisibüroo administraatorid
* Kliendihaldurid ja reisikonsultandid

### Kasutatud tehnoloogiad
* **Backend:** C# (.NET Core)
* **Andmebaasi raamistik:** Entity Framework Core (SQL Server, Code-First lähenemine)
* **Frontend:** ASP.NET Core Razor Views (HTML5, CSS3)
* **Disainiraamistik:** Bootstrap 5 (põhineb puhtal ja kaasaegsel kaartide süsteemil)

### Paigaldusjuhend
1. Klooni antud repositoorium oma arvutisse, kasutades git clone käsku.
2. Ava fail `TourManagementSystem.sln` programmiga Microsoft Visual Studio.
3. Kontrolli üle andmebaasi ühendussõne (Connection String) failis `appsettings.json`, et see sobiks sinu kohaliku SQL Serveriga.
4. Vajuta Visual Studios **Run** (roheline kolmnurk) või klaviatuuril `F5`.
5. Rakendus loob käivitumisel automaatselt vajaliku andmebaasi ja tabelid tänu `context.Database.EnsureCreated()` funktsioonile.

### Kasutusjuhend
* **Pealeht (Index):** Rakenduse käivitumisel avaneb kohe reiside kataloog (Tours Catalog), kus on näha reiside kaardid koos hindade ja sihtkohtadega.
* **Uue reisi lisamine (Create):** Vajuta nupule "+ Add New Tour", täida väljad ja salvesta.
* **Andmete vaatamine (Details):** Vajuta reisi kaardil nupule "Details", et näha reisi üksikasju.
* **Muutmine (Edit):** Vajuta nupule "Edit", muuda andmed ja uuenda.
* **Kustutamine (Delete):** Vajuta nupule "Delete", süsteem küsib kinnitust ja seejärel eemaldab reisi andmebaasist.

### Tehisintellekti (AI) kasutamise dokumentatsioon
* **Kasutatud tööriist:** Gemini (Google)
* **Dokumenteeritud tegevus:** Tehisintellekti kasutati koodi refaktoreerimiseks (üleliigsete lokaliseerimisseadete eemaldamiseks failist `Program.cs`), Razor vaadete vigade tuvastamiseks (näiteks `@item.Id` muutuja parandamine `Details.cshtml` lehel) ning ingliskeelsele disainile ülemineku toetamiseks. Kogu rakenduse baasfunktsionaalsus ja CRUD-loogika tugineb standardsetele õppematerjalidele.

### Kasutatud allikad ja viited
* Microsoft Learn: ASP.NET Core MVC koonddokumentatsioon
* Bootstrap 5: Küljenduse, kaartide (Cards) ja nuppude dokumentatsioon


### Autorid ja rollid

* ** Liliia Melnyk ** — *Roll: Full-stack arendaja*
  * Teostas C# backend loogika ja andmebaasi liidestamise (Entity Framework Core). Hallata Giti repositooriumi ja lahendas koodis esinenud vead.

* ** Johanna Tima ** — *Roll: Projektijuht / UI/UX Disainer*
  * Juhtis projekti tähtaegu ja planeerimist. Vastutas visuaalse poole eest: disainis kaasaegse rohelise bänneri, reiside kaardid (Cards) ning tagas liidese puhta välimuse.

* ** Jelizaveta Sukhomlynova ** — *Roll: Testija / Dokumenteerija*
  * Viis läbi rakenduse funktsionaalsuse testimise (Details, Edit ja Delete funktsioonide kontroll). Koostas projekti lõppdokumentatsiooni ja `README.md` faili.