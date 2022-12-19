# Oefencase

## Blok 1: Programming Essentials

Maak een Galgje-console-applicatie.

* Schrijf unittests die de werking van het spel controleren.
* Toon welke letters al zijn gegokt.
* Het spel moet gereset te kunnen worden.
* Het resultaat van het spel hoort duidelijk aangegeven te worden.

Tijd over?

* Hou de volgende statistieken bij over de laatste 10 gespeelde potjes:
  * Hoeveel foute letters worden er gegokt
  * Hoelang men erover doet om een woord te raden
  * Uiteraard met unittests
* Bied een menu-optie aan waarop te zien is welke speler het meeste aantal woorden goed heeft geraden en wie de beste ratio heeft (geraden vs niet geraden)

## Blok 2: Developing Databases and XML

Gebruik een database om high scores en statistieken van het spel op te slaan.

* Zet Entity Framework Core in om de database te ontsluiten.
* Voor het aanmaken van de database mogen migrations gebruikt worden, maar de database mag ook met de hand worden aangemaakt.
* Hou de volgende statistieken bij over de laatste 10 gespeelde potjes:
  * Hoeveel foute letters worden er gegokt
  * Hoelang men erover doet om een woord te raden
* Bied een menu-optie aan waarop te zien is welke speler het meeste aantal woorden goed heeft geraden en wie de beste ratio heeft (geraden vs niet geraden)
* Haal het te raden woord middels een stored procedure op uit de database. Gebruik ook hier Entity Framework Core.

Tijd over?

* Controleer met SQL Server Extended Events of de gegenereerde queries van Entity Framework Core efficiënt zijn. Denk hierbij aan:
  * Navigation properties die per ongeluk niet geïnclude zijn, waardoor er per entity een query wordt uitgevoerd
  * Queries die te veel data ophalen met onnodige joins of onnodig veel kolommen in de resultset
  * Filteren/groeperen wat per ongeluk in .NET wordt gedaan in plaats van de database

## Blok 3: Advanced Programming

Maak een ASP.NET Core-webfrontend waar men op een visuele manier het spel kan spelen. Gebruik Azure om een REST API te definiëren.

* Hergebruik zoveel mogelijk logica van de voorgaande opdrachten.
* Visualiseer de "voortgang" van het spel.
* Gebruik nog geen JavaScript bij deze opdracht. Stuur dus volledige HTTP-requests bij het gokken van letters en render server-side een geheel nieuwe view.
* Maak verschillende pagina's voor o.a. het spel, maar ook de statistieken en de high scores.
* Gebruik `async`/`await` voor I/O-operaties.

Tijd over?

* Implementeer een pay-to-play-model voor je applicatie via een Azure-service. Iedere unieke gebruiker mag 3 keer gratis spelen, daarna moet hij of 5 minuten wachten of betalen voor 3 nieuwe rondes.
* Implementeer logging en hou performance counters bij over hoeveel load de service te verduren krijgt.

## Blok 4: Crypto, Data en OS

Sla alle persoonsgegevens versleuteld op in verband met privacywetgeving (GDPR), zoals de spelernaam en tijdstippen waarop een spel is gestart en beëindigd. Gebruik voor deze versleuteling X509-certificaten.

Tijd over?

* Verbeter je unittests met nieuw verkregen inzichten van de training.

## Blok 5: Front End Development

Gebruik JavaScript i.c.m. AJAX om het spel te laten werken. Hierbij kun je voor verschillende opzetten gaan:

* Iedere lettergok naar de server communiceren via AJAX
* Het te raden woord via AJAX ophalen van de server, de werking van het spel met JavaScript regelen en alle statistieken en het resultaat opsturen wanneer het spel klaar is

Als je het aandurft, mag je er ook voor kiezen om de voorkant te herbouwen met een lichtgewicht view library als Svelte, Vue of React. Gebruik hier dan ook gerust TypeScript bij. Het `any` keyword is dan verboden.

