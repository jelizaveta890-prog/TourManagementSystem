# Tour Management System – Reisihaldussüsteem

## Projekti kirjeldus
Tour Management System on ASP.NET Core MVC veebirakendus reiside haldamiseks. Süsteem võimaldab reise lisada, vaadata, muuta ja kustutada ning salvestab andmed SQL Serveri andmebaasi.

## Kasutatud tehnoloogiad
- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- HTML5, CSS3

## Paigaldusjuhend
1. Klooni või laadi projekt alla.
2. Ava projekt Visual Studios.
3. Kontrolli andmebaasi ühendust failis `appsettings.json`.
4. Käivita projekt (F5).

## Kasutusjuhend
- Vaata reiside nimekirja avalehel.
- Lisa uus reis nupuga **Add New Tour**.
- Muuda reisi nupuga **Edit**.
- Vaata üksikasju nupuga **Details**.
- Kustuta reis nupuga **Delete**.

### Autorid ja rollide jaotus

* **Liliia Melnyk** (Full-stack arendaja)
  * Kirjutas C# backend’i ja pani paika andmebaasi poole (Entity Framework Core). Tegeles ka Giti repositooriumi haldamisega ja parandas koodis tekkinud vigu.


* **Johanna Tima** (Projektijuht/Disainer)
*Jälgis, et asjad saaksid õigeks ajaks valmis ja tegeles planeerimisega.
*Aitas kaasa veebilehe disaini loomisele ning pakkus välja erinevaid disainiideid.

* **Jelizaveta Sukhomlynova** (Testija/Dokumenteerija)
*Testis programmi funktsioonid läbi (kontrollis, et Details, Edit ja Delete nupud reaalselt töötaksid ilma vigadeta). 
*Pani kokku projekti lõppdokumentatsiooni ja README.md faili.