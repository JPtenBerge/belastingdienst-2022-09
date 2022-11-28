# Labs

We gaan een Todo-webapplicatie maken.

1. Toon een lijst van todo’s op de pagina. Een todo bestaat uit:
   * De taak die gedaan moet worden.
   * Wanneer het gedaan moet zijn.
   * Of het al klaar is.
1. Voeg een formulier toe boven de tabel om nieuwe todos toe te voegen. Met server-side formuliervalidatie natuurlijk.
1. Zorg ervoor dat een todo kan worden “Af”  gevinkt.
1. Creëer een repository die het stukje data access afhandelt. Voor nu simpelweg een in-memory repository. In een toekomstige oefening gaan we een repository toevoegen die verbinding maakt met een database.
1. Unittest een interessant stukje van jullie pagina.
1. Sla jullie todos op in een database.
   - kies maar even wat het makkelijkst is als databasesysteem (docker, mysql, sqlite, in-memory) - behalve als je Falco heeft
1. Maak een stuk middleware die alle 404's logt.
1. Hang jullie todo onder een categorie: Huishoudelijk, Relatiemanagement, ...
1. Maak twee controllers voor het benaderen van jullie data:
   - Todo endpoint: ophalen, toevoegen & (if time permits) afvinken met een patch
   - Category endpoint: enkel ophalen
1. Creëer een kleine Blazor WebAssembly-webapp die todo's ophaalt van de server en toont in een lijstje.
1. Het wordt een familie-todo-app. Registreer bij iedere todo wie hem heeft toegevoegd. En men moet dus zijn ingelogd om todos toe te voegen.
   - Kies zelf maar of je Azure AD wil gebruiken of je lokale database wil gebruiken
   - Laat de Blazor-app maar even links liggen voor nu



- API richting database
  - die lijken allemaal wel op elkaar, maar zijn net wel overal een beetje anders
  - SFL.cs - 32.000
    - FoxPro
    - SQL Server
    - DB2
  