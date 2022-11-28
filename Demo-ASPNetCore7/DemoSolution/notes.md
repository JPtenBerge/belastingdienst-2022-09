# Notes ASP.NET Core with Razor Pages

## About

ASP.NET - 2002
- WebForms
- MVC - 2008
- .NET Framework, niet cross-platform
- serverside

ASP.NET Core - 2016
- MVC Model Controller - APIs
- Razor Pages (pagina-georienteerde)
- serverside


Blazor - webapplicatieframework
- meer het model van de razor pages
- razor pages met components
- server-side logica uitvoeren in client
- client-side
- WebAssembly (hello world = 7MB) / Server
  - 25kb
  - intranet

Project aanmaken:
- ASP.NET Core Empty - wat meer werk, maar je weet wel wat er gedaan wordt
- ASP.NET Core Web App - minder werk, veel wordt gedaan voor je
  - niet de MVC-variant
  - zonder security - geen auth - https is prima

## jQuery

voordelen jQuery:

- AJAX

    ```js
    $.getJSON('api/whatever').then(x => { });
    fetch('api/whatever').then(x => x.json()).then(x => { ... });
    ```

- DOM manipulatie
  - Daar zijn andere libraries simpelweg beter in/chiquer bij:
    - Angular
    - Svelte
    - Vue
    - React - facebook

- browserabstractie
  - IE6
    ```js
    var btn = document.getElementById('btn');
    if (btn.addEventListener) { // alle andere browser
        btn.addEventListener('click', function() {

        });
    }
    else { // IE 6 7 8
        btn.attachEvent('onclick', function() {

        });
    }

    $('#btn').click(function() {

    });
    ```

## Dependency Injection??

- een vorm van inversion of control (IoC)
- handig met unittesten

ELI5 - Explain Like I'm 5 - kind heeft dorst, behoefte aan drinken uitspreken richting ouders.

## Soorten testen (herhaling)

unittesten
- stukjes code

integratietesten
- http-requests
  - Test of statuscode en header terug wordt gestuurd - `Location: ...`

end-to-end testen
- browser automatiseren

## Entity Framework Core

- ORM: Object-Relational Mapper

- `DbContext<>`
- `DbSet<>`

Alternatieven:
- EF6
- Dapper (van StackExchange)
- Belgrade
- NHibernate

## REST

REpresentational State Transfer API

- manier om applicatie naar buitenwereld open te zetten naar de mensen en data die je wil

- endpoints om data vandaan te halen
  - JSON
  - XML

  HTTP header "Accept: text/html, application/xml, application/json"

- soort request - HTTP verb
  - GET		op te halen
  - POST		toevoegen   /wijzigen
  - PUT		wijzigen    /toevoegen
  - DELETE    verwijderen
  - PATCH		deel wijzigen

  GET index.php?action=delete_customer&id=14


POST  /api/car     { make: '...', model: '...' }
POST  /api/car     { make: '...', model: '...' }
POST  /api/car     { make: '...', model: '...' }
POST  /api/car     { make: '...', model: '...' }
POST  /api/car     { make: '...', model: '...' }
POST  /api/car     { make: '...', model: '...' }

6 nieuwe auto's

PUT  /api/car/15     { make: '...', model: '...' }
PUT  /api/car/15     { make: '...', model: '...' }
PUT  /api/car/15     { make: '...', model: '...' }
PUT  /api/car/15     { make: '...', model: '...' }
PUT  /api/car/15     { make: '...', model: '...' }
PUT  /api/car/15     { make: '...', model: '...' }

1 nieuwe auto

idempotency

eenduidigheid

- docs van API
- HTTP

Lastige dingen met REST?

- Processen uitdrukken in resources
  - Prima:
    ```sh
    /api/car
    /api/product
    /api/human
    ```

  - Lastiger:
    ```sh
    /api/vergunning-aanvragen
    /api/rijbewijs-aanvragen
    /api/rechtzaak
    ```
- versioneren
  ```sh
  /api/v1/car
  /api/v2/car
  /api/v3/car
  ```

API testing tools:
- curl (CLI)
- Postman (GUI)
- Insomnia (GUI). Vind ikzelf fijner dan Postman want:
  - Had eerder een dark theme
  - Rustigere UI
  - Had bepaalde features eerder: gRPC
- Thunder Client (VS Code extensie)
- REST Client (bestandjes .rest/.http, handig voor hergebruik).

### HTTP-statuscodessen

REST - HTTP - statuscodessen

2xx - SUCCESS
- 200 OK
- 201 Created     (vaak bij POST)
- 204 No Content  (vaak bij DELETE)

3xx - redirect
- 301/302 - permanent/tijdelijk

4xx - client error
- 400 Bad Request
- 401/403 Unauthorized/Forbidden
- 404 Not Found
- 405 Method not allowed - POST waar geen POST ondersteund wordt
- 415 Mediatype not supported - XML stuurt naar een endpoint die XML niet kan parsen
- 418 I'm a teapot - 1 april 1999

5xx - server error
- 500 Internal Server Error
- 502 Bad Gateway



### REST maturity levels

Plain Old XML

/api/...

GET POST PUT PATCH DELETE

Hypermedia As The Engine Of Application State

```json
{
	"name": "JP",
	"age": 36,
	"links": [
		{ "girlfriend": "api/36/girlfriend" },
		{ "employes": "api/employer/infosupport" },
	]
}
```

publieke APIs
client (SPA - blazor/angular/vue) <==> server (APIs)




DTO's
- Data Transfer Objects

GetRequestMessage
GetResponseMessage

POCO's

AutoMapper
Mapster




ASP.NET Core
1.0    Newtonsoft.Json
2.0    Newtonsoft.Json
3.0    System.Text.Json - blazor
       - circulaire referenties
5.0    eindelijk wel circ. ref.


## Blazor

- frontendframework
- Microsoft
- lijkt heel erg op Razor Pages
  @bla
- C#

Blazor WebAssembly
- jouw code draait in de browser
  - dankzij HTML5's WebAssembly - Rust
- microversie van .NET
  - 7MB (hello world)
  - 2MB (de meest geoptimaliseerde variant die ik langs heb zien komen)

Blazor Server
- jouw code draait op de server
- SignalR (websocket)
- er hoeft niet heel veel data te worden gestuurd naar de frontend
- je moet wel continu een verbinding open hebben staan


.dll
.dll.br - Brotli
.dll.gz - GZip

- matblazor mudblazor antdesign  (UI-framework)


### Blazor en unittesten

sommige dingen kan ik niet unittesten:

```html
<input @ref="InputIets">
```
```cs
public ElementReference InputIets { get; set; } // ElementReference = struct

//...

await InputIets.FocusAsync();
```
In test:
```cs
new Mock<ElementReference>(); // - no no

### Waarom WebAssembly?

```sh
gecompileerde code           > geinterpreteerde code

C C++  Java C#  VB  Rust           JS  Python  PHP
WebAssembly                    
```

JS
- flexibel
- dynamisch

```js
let obj = { x: 24, y: 'hoi' };
obj.z = 34935;
delete obj.x;

let x = 'www';
x = 24;
x = {};
x = [];
x = [true, 42, 'www', "qqq", `qwsdf`, {}, []];

// TypeScript !== typesafe

2 == '2' // true
2 === '2' // false

let verdieping = 0;
if(!verdieping) { undefined null 0
	
}
```

CORS? Cross-origin resource sharing
- beveiligingsfeature

